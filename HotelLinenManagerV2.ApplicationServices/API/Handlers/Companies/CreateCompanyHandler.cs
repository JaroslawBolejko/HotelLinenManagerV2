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

        public CreateCompanyHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor ,IMapper mapper, IGUSDataConnector gUSDataConnector)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.gUSDataConnector = gUSDataConnector;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {

            var daneZGUS = await this.gUSDataConnector.szukajPodmioty<RootDaneSzukajPodmioty>(request.TaxNumber);

            var result = string.IsNullOrEmpty(request.City) && string.IsNullOrEmpty(request.Name) && string.IsNullOrEmpty(request.Number)
                && string.IsNullOrEmpty(request.Street) && string.IsNullOrEmpty(request.ZipCode);

            if (result == true)
            {
                request.City = daneZGUS.Dane.Miejscowosc;
                request.Name = daneZGUS.Dane.Nazwa;
                request.Number = daneZGUS.Dane.NrNieruchomosci;
                //przerób na stringa
                //request.ApartmentNumber = Convert.ToUInt16(daneZGUS.Dane.NrLokalu);
                request.Street = daneZGUS.Dane.Ulica;
                request.ZipCode = daneZGUS.Dane.KodPocztowy;
            }

            var query = new GetCompaniesQuery()
            {
                Name = request.Name,
                TaxNumber = request.TaxNumber
                //Name = daneZGUS.Dane.Nazwa
            };
            var companiesFromDb = await this.queryExecutor.Execute(query);
            if (companiesFromDb != null)
            {
                return new CreateCompanyResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict+" Podana firma istnie już w bazie dancyh!")
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
