using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class CreateHotelLinenHandler : IRequestHandler<CreateHotelLinenRequest, CreateHotelLinenResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public CreateHotelLinenHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateHotelLinenResponse> Handle(CreateHotelLinenRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new CreateHotelLinenResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetHotelLinensQuery()
            {
               HotelLinenTypeId =  request.HotelLinenTypeId,
               NameWithShortDescription = request.NameWithShortDescription,
               WarehauseId = request.WarehauseId
            };
            var getWarhause = await this.queryExecutor.Execute(query);
            if (getWarhause != null)
            {
                return new CreateHotelLinenResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict+" Bielizna o podanym typie oraz nazwie już istnieje!")
                };
            }
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
