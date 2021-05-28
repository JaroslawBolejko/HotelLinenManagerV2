using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Warehauses
{
    public class CreateWarehauseHandler : IRequestHandler<CreateWarehauseRequest, CreateWarehauseResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public CreateWarehauseHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateWarehauseResponse> Handle(CreateWarehauseRequest request, CancellationToken cancellationToken)
        {
            var mappedWarehause = this.mapper.Map<DataAccess.Entities.Warehause>(request);
            var command = new CreateWarehauseCommand()
            {
                Parameter = mappedWarehause
            };
            var wareHauseFromDB = await this.commandExecutor.Execute(command);
            return new CreateWarehauseResponse()
            {
                Data = this.mapper.Map<Domain.Models.Warehause>(wareHauseFromDB)
            };
        }
    }
}
