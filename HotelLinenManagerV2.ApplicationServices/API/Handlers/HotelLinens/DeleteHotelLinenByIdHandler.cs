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
    public class DeleteHotelLinenByIdHandler : IRequestHandler<DeleteHotelLinenByIdRequest, DeleteHotelLinenByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeleteHotelLinenByIdHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteHotelLinenByIdResponse> Handle(DeleteHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new DeleteHotelLinenByIdResponse
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
                return new DeleteHotelLinenByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedCommand = this.mapper.Map<HotelLinen>(request);
            var command = new DeleteHotelLinenByIdCommand()
            {
                Parameter = mappedCommand
            };
            var deletedHotelLinen = await this.commandExecutor.Execute(command);
            var response = new DeleteHotelLinenByIdResponse()
            {
                Data = deletedHotelLinen
            };
            return response;
        }
    }
}
