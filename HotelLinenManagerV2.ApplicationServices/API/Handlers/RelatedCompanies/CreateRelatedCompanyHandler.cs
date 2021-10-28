using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.RelatedCompanies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.RelatedCompanies;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.RelatedCompanies;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.RelatedCompanies;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.RelatedCompanies
{
    public class CreateRelatedCompanyHandler : IRequestHandler<CreateRelatedCompanyRequest, CreateRelatedCompanyResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public CreateRelatedCompanyHandler(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateRelatedCompanyResponse> Handle(CreateRelatedCompanyRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllRelatedCompaniesQuery()
            {
               
                CompanyId = request.CompanyId,
                LaundryId = request.LaundryId
            };

            var user = await this.queryExecutor.Execute(query);
            if (user != null)
            {
                return new CreateRelatedCompanyResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };

            }

            var mappedReleatedCompany = this.mapper.Map<RelatedCompany>(request);
            var command = new CreateRelatedCompanyCommand()
            {
                Parameter = mappedReleatedCompany
            };
            var createdRelatedCompany = await this.commandExecutor.Execute(command);

            return new CreateRelatedCompanyResponse()
            {
                Data = this.mapper.Map<Domain.Models.RelatedCompany>(createdRelatedCompany)
            };
        }
    }
}
