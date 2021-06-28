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
    public class DeleteCompanyByIdHandler : IRequestHandler<DeleteCompanyByIdRequest, DeleteCompanyByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeleteCompanyByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor,IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteCompanyByIdResponse> Handle(DeleteCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationCompanyId != request.Id)
            {
                return new DeleteCompanyByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.UnsupportedMethod)
                };
            }

            var query = new GetCompanyQuery()
            {
                Id = request.Id
            };
            var companiesFromDb = await this.queryExecutor.Execute(query);
            if (companiesFromDb == null)
            {
                return new DeleteCompanyByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedCommand = this.mapper.Map<Company>(request);
            var command = new DeleteCompanyCommand()
            {
                Parameter = mappedCommand
            };
            var deletedCompany = await this.commandExecutor.Execute(command);
            var response = new DeleteCompanyByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Company>(deletedCompany)
            };
            return response;
        }
    }
}
