using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
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

        public CreateCompanyHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor ,IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
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
