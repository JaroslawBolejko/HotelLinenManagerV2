using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using HotelLinenManagerV2.ApplicationServices.Components.GUSDataConnector;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Companies;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Companies;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Companies
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        private readonly IGUSDataConnector gUSDataConnector;
        private readonly ILogger logger;

        public CreateCompanyHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor,
            IMapper mapper, IGUSDataConnector gUSDataConnector, ILogger<CreateCompanyHandler> logger)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.gUSDataConnector = gUSDataConnector;
            this.logger = logger;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole != "HotelAdmin")
            {
                return new CreateCompanyResponse()
                {
                    Error = new ErrorModel(ErrorType.UnsupportedMethod)
                };
            }
            try
            {

                var isEmpty = string.IsNullOrEmpty(request.City) || string.IsNullOrEmpty(request.Name)
                    || string.IsNullOrEmpty(request.Number) || string.IsNullOrEmpty(request.Street)
                    || string.IsNullOrEmpty(request.Street) || string.IsNullOrEmpty(request.ApartmentNumber);
                

                if (isEmpty == true)
                {
                    var daneZGUS = await this.gUSDataConnector.szukajPodmioty<RootDaneSzukajPodmioty>(request.TaxNumber);

                    request.City = daneZGUS.Dane.Miejscowosc;
                    request.Name = daneZGUS.Dane.Nazwa;
                    request.Number = daneZGUS.Dane.NrNieruchomosci;
                    request.ApartmentNumber = daneZGUS.Dane.NrLokalu;
                    request.Street = daneZGUS.Dane.Ulica;
                    request.ZipCode = daneZGUS.Dane.KodPocztowy;

                    // this.mapper.Map(daneZGUS.Dane, request); TU popracować jak to zmapować?
                    this.logger.LogInformation("Pobrano dane z GUS");
                }
                var isNameEmpty = string.IsNullOrEmpty(request.Name);
                if (isNameEmpty == true)
                {
                    this.logger.LogError("Podano nieistniejący w bazie GUS NIP");
                    return new CreateCompanyResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound + " Podana firma nie istnieje w bazie GUS!")
                    };
                }


            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Application faild to retrive data from GUS");
            }

            var query = new GetCompaniesQuery()
            {
                Name = request.Name,
                TaxNumber = request.TaxNumber
            };
            var companiesFromDb = await this.queryExecutor.Execute(query);
            if (companiesFromDb != null)
            {
                return new CreateCompanyResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict + " Podana firma istnie już w bazie dancyh!")
                };
            }
            var mappedCommand = this.mapper.Map<Company>(request);
            var command = new CreateCompanyCommand()
            {
                Parameter = mappedCommand
            };
            var createdCompany = await this.commandExecutor.Execute(command);
            var response = new CreateCompanyResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Company>(createdCompany)
            };
            return response;
        }
    }
}
