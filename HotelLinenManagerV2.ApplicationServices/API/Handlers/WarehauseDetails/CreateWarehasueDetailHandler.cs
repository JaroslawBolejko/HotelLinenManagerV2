using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.WarehauseDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.WarehauseDetails;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.WarehauseDetails;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Warehauses
{
    public class CreateWarehauseDetailHandler : IRequestHandler<CreateDetailsRequest, CreateDetailsResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public CreateWarehauseDetailHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateDetailsResponse> Handle(CreateDetailsRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new CreateDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetAllWarehauseDetailsQuery()
            {
              WarehauseId = request.WarehauseId,
              HotelLinenId = request.HotelLinenId
            };

            var details = await this.queryExecutor.Execute(query);

            if (details != null)
            {
                return new CreateDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }

            var mappedDetails = this.mapper.Map<DataAccess.Entities.WarehauseDetail>(request);
            var command = new CreateWarehauseDetailCommand()
            {
                Parameter = mappedDetails
            };

            var detailsFromDB = await this.commandExecutor.Execute(command);
            return new CreateDetailsResponse()
            {
                Data = this.mapper.Map<Domain.Models.WarehauseDetail>(detailsFromDB)
            };
        }
    }
}