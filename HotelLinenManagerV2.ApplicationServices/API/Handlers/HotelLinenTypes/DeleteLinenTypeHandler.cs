using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinenTypes;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinenTypes;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinenTypes;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class DeleteLinenTypeHandler : IRequestHandler<DeleteLinenTypeByIdRequest, DeleteLinenTypeByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeleteLinenTypeHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteLinenTypeByIdResponse> Handle(DeleteLinenTypeByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new DeleteLinenTypeByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetLinenTypeQuery()
            {
                Id = request.Id
            };
            var getType = await this.queryExecutor.Execute(query);

            if (getType == null)
            {
                return new DeleteLinenTypeByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedCommand = this.mapper.Map<HotelLinenType>(request);
            var command = new DeleteLinenTypeCommand()
            {
                Parameter = mappedCommand
            };
            var deletedType = await this.commandExecutor.Execute(command);
            var response = new DeleteLinenTypeByIdResponse()
            {
                Data = deletedType
            };
            return response;
        }
    }
}
