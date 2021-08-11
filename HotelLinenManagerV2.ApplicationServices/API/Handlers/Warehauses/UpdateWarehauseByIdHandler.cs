using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Warehauses;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Warehauses
{
    public class UpdateWarehauseByIdHandler : IRequestHandler<UpdateWarehauseByIdRequest, UpdateWarehauseByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExeceutor;
        private readonly IMapper mapper;

        public UpdateWarehauseByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExeceutor ,IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExeceutor = queryExeceutor;
            this.mapper = mapper;
        }

        public async Task<UpdateWarehauseByIdResponse> Handle(UpdateWarehauseByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new UpdateWarehauseByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetWarehauseQuery()
            {
                Id=request.Id
            };
            var getWarehause = await this.queryExeceutor.Execute(query);

            if (getWarehause == null)
            {
                return new UpdateWarehauseByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var warhause = this.mapper.Map<Warehause>(request);

            var command = new UpdateWarehauseCommand() 
            {
                Parameter = warhause
            };
            var updatedWarehause = await this.commandExecutor.Execute(command);
            var response = new UpdateWarehauseByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Warehause>(updatedWarehause)
            };
            return response;

        }
    }
}
