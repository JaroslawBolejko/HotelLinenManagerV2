using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Warehauses
{
    public class UpdateWarehauseByIdHandler : IRequestHandler<UpdateWarehauseByIdRequest, UpdateWarehauseByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public UpdateWarehauseByIdHandler(ICommandExecutor commandExecutor,IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<UpdateWarehauseByIdResponse> Handle(UpdateWarehauseByIdRequest request, CancellationToken cancellationToken)
        {
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
