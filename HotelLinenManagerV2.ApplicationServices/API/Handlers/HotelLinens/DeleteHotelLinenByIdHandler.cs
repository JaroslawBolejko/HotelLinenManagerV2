using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class DeleteHotelLinenByIdHandler : IRequestHandler<DeleteHotelLinenByIdRequest, DeleteHotelLinenByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteHotelLinenByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteHotelLinenByIdResponse> Handle(DeleteHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {
            var mappedCommand = this.mapper.Map<HotelLinen>(request);
            var command = new DeleteHotelLinenByIdCommand()
            {
                Parameter = mappedCommand
            };
            var deletedHotelLinen = await this.commandExecutor.Execute(command);
            var response = new DeleteHotelLinenByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.HotelLinen>(deletedHotelLinen)
            };
            return response;
        }
    }
}
