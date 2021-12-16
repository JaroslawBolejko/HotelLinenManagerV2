using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class PatchHotelLinenByIdHandler : IRequestHandler<PatchHotelLinenByIdRequest, PatchHotelLinenByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public PatchHotelLinenByIdHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<PatchHotelLinenByIdResponse> Handle(PatchHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {

            if (request.AuthenticationRole == "UserLaundry")
            {
                return new PatchHotelLinenByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Forbidden)
                };
            }
            var query = new GetHotelLinenQuery()
            {
                Id = request.Id
            };
            var getHotelLinen = await this.queryExecutor.Execute(query);

            if (getHotelLinen == null)
            {
                return new PatchHotelLinenByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var hotelLinenModel = this.mapper.Map<API.Domain.Models.HotelLinen>(getHotelLinen);

            request.LinenUpdate.ApplyTo(hotelLinenModel);

            var hotelLinenEntity = this.mapper.Map<DataAccess.Entities.HotelLinen>(hotelLinenModel);

            var command = new UpdateHotelLinenByIdCommand()
            {
                Parameter = hotelLinenEntity
            };

            var updatedHotelLinen = await this.commandExecutor.Execute(command);
            var resopnse = new PatchHotelLinenByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.HotelLinen>(updatedHotelLinen)
            };
            return resopnse;
        }
    }
}

