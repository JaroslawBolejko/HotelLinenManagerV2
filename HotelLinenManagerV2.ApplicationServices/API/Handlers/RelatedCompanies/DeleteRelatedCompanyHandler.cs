using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.RelatedCompanies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.RelatedCompanies;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.RelatedCompanies;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.RelatedCompanies;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.RelatedCompanies
{
    public class DeleteRelatedCompanyHandler : IRequestHandler<DeleteRelatedCompanyRequest, DeleteRelatedCompanyResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteRelatedCompanyHandler(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteRelatedCompanyResponse> Handle(DeleteRelatedCompanyRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRelatedCompanyQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteRelatedCompanyResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedRelatedCompany = this.mapper.Map<RelatedCompany>(request);

            var command = new DeleteRelatedCompanyCommand()
            {
                Parameter = mappedRelatedCompany
            };
            var fromDB = await this.commandExecutor.Execute(command);

            return new DeleteRelatedCompanyResponse()
            {
                Data = fromDB
            };
        }
    }
}
