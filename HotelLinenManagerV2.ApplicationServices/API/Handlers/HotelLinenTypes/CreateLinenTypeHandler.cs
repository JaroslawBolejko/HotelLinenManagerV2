using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinenTypes;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinenTypes;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinenTypes;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class CreateLinenTypeHandler : IRequestHandler<CreateLinenTypeRequest, CreateLinenTypeResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public CreateLinenTypeHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateLinenTypeResponse> Handle(CreateLinenTypeRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new CreateLinenTypeResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetAllLinenTypesQuery()
            {
                TypeName = request.TypeName,
                Size = request.Size,
                Weight = request.Weight
            };
            var getLinenType = await this.queryExecutor.Execute(query);
            if (getLinenType != null)
            {
                return new CreateLinenTypeResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }
            var mappedCommand = this.mapper.Map<HotelLinenType>(request);
            var command = new CreateLineTypeCommand()
            {
                Parameter = mappedCommand
            };
            var createdHotelLinen = await this.commandExecutor.Execute(command);

            var response = new CreateLinenTypeResponse()
            {

                Data = this.mapper.Map<API.Domain.Models.HotelLinenType>(createdHotelLinen)

            };

            return response;
        }
    }
}
