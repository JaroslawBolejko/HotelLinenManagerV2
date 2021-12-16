using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Warehauses;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Warehauses
{
    public class DeleteWarehauseByIdHandler : IRequestHandler<DeleteWarehauseByIdRequest, DeleteWarehauseByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeleteWarehauseByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor,IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteWarehauseByIdResponse> Handle(DeleteWarehauseByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new DeleteWarehauseByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Forbidden)
                };
            }

            var query = new GetWarehauseQuery()
            { 
                Id=request.Id
            };
            var getWarehause = await this.queryExecutor.Execute(query);
            if(getWarehause==null)
            {
                return new DeleteWarehauseByIdResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            var warhause = this.mapper.Map<Warehause>(request);
            var command = new DeleteWarhauseCommand()
            {
                Parameter = warhause
            };
            var deletedWarhause = await this.commandExecutor.Execute(command);
            var resopnse = new DeleteWarehauseByIdResponse()
            {
                Data = deletedWarhause
            };
            return resopnse;

        }
    }
}
