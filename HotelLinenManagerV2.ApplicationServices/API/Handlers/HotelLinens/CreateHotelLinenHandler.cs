using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class CreateHotelLinenHandler : IRequestHandler<CreateHotelLinenRequest, CreateHotelLinenResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public CreateHotelLinenHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateHotelLinenResponse> Handle(CreateHotelLinenRequest request, CancellationToken cancellationToken)
        {
            var mappedCommand = this.mapper.Map<HotelLinen>(request);
            var command = new CreateHoteLinenCommand()
            {
                Parameter = mappedCommand 
            };
            var createdHotelLinen = await this.commandExecutor.Execute(command);
            var response = new CreateHotelLinenResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.HotelLinen>(createdHotelLinen)
            };
            return response;
        }
    }
}
