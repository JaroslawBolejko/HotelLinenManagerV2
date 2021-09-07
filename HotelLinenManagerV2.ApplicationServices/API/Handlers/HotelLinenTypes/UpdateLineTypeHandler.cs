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
    public class UpdateLinenTypeHandler : IRequestHandler<UpdateLinenTypeByIdRequest, UpdateLinenTypeByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public UpdateLinenTypeHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<UpdateLinenTypeByIdResponse> Handle(UpdateLinenTypeByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new UpdateLinenTypeByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetLinenTypeQuery()
            {
                Id = request.Id
            };
            var getLinenType = await this.queryExecutor.Execute(query);

            if (getLinenType == null)
            {
                return new UpdateLinenTypeByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedLinenType = this.mapper.Map<HotelLinenType>(request);
            var command = new UpdateLinenTypeCommand()
            {
                Parameter = mappedLinenType
            };
            var updatedLinenType = await this.commandExecutor.Execute(command);
            var response = new UpdateLinenTypeByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.HotelLinenType>(updatedLinenType)
            };
            return response;
        }
    }
}
