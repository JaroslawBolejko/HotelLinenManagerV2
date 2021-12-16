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
    public class UpdateCompanyByIdHandler : IRequestHandler<UpdateCompanyByIdRequest, UpdateCompanyByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public UpdateCompanyByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor ,IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<UpdateCompanyByIdResponse> Handle(UpdateCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            if(request.AuthenticationCompanyId != request.Id)
            {
                return new UpdateCompanyByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Forbidden)
                };
            }

            var query = new GetCompanyQuery() 
            {
                Id = request.Id
            };
            var getCompany = await this.queryExecutor.Execute(query);
            if(getCompany==null)
            {
                return new UpdateCompanyByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedCommand = this.mapper.Map<Company>(request);
            var command = new UpdateCompanyCommand()
            {
                Parameter = mappedCommand
            };
            var updatedCompany = await this.commandExecutor.Execute(command);
            var response = new UpdateCompanyByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Company>(updatedCompany)
            };
            return response;
        }
    }
}
