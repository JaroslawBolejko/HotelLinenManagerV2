using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Warehauses
{
    public class DeleteWarehauseByIdHandler : IRequestHandler<DeleteWarehauseByIdRequest, DeleteWarehauseByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteWarehauseByIdHandler(ICommandExecutor commandExecutor,IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteWarehauseByIdResponse> Handle(DeleteWarehauseByIdRequest request, CancellationToken cancellationToken)
        {

            var warhause = this.mapper.Map<Warehause>(request);
            var command = new DeleteWarhauseCommand()
            {
                Parameter = warhause
            };
            var deletedWarhause = await this.commandExecutor.Execute(command);
            var resopnse = new DeleteWarehauseByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Warehause>(deletedWarhause)
            };
            return resopnse;

        }
    }
}
