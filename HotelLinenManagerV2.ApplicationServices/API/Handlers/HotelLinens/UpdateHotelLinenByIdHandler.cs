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
    public class UpdateHotelLinenByIdHandler : IRequestHandler<UpdateHotelLinenByIdRequest, UpdateHotelLinenByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public UpdateHotelLinenByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<UpdateHotelLinenByIdResponse> Handle(UpdateHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {
            var mappedhotelLinen = this.mapper.Map<HotelLinen>(request);
            var command = new UpdateHotelLinenByIdCommand()
            {
                Parameter = mappedhotelLinen
            };
            var updatedHotelLinen = await this.commandExecutor.Execute(command);
            var resopnse = new UpdateHotelLinenByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.HotelLinen>(updatedHotelLinen)
        };
        return resopnse;
        }
    }
}
