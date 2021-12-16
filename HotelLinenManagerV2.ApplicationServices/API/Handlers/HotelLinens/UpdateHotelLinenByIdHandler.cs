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
    public class UpdateHotelLinenByIdHandler : IRequestHandler<UpdateHotelLinenByIdRequest, UpdateHotelLinenByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public UpdateHotelLinenByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor ,IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<UpdateHotelLinenByIdResponse> Handle(UpdateHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new UpdateHotelLinenByIdResponse
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
                return new UpdateHotelLinenByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
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
