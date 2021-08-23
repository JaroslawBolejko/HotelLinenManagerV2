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
    public class DeleteWarehauseDetailsHandler : IRequestHandler<DeleteDetailsByIdRequest, DeleteDetailsByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeleteWarehauseDetailsHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteDetailsByIdResponse> Handle(DeleteDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            //if (request.AuthenticationRole == "UserLaundry")
            //{
            //    return new DeleteDetailsByIdResponse()
            //    {
            //        Error = new ErrorModel(ErrorType.Unauthorized)
            //    };
            //}

            var query = new GetWarehauseDetailQuery()
            {
                Id = request.Id
            };

            var details = await this.queryExecutor.Execute(query);

            if (details == null)
            {
                return new DeleteDetailsByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDetails = this.mapper.Map<DataAccess.Entities.WarehauseDetail>(request);
            var command = new DeleteWarehauseDetailCommand()
            {
                Parameter = mappedDetails
            };

            var detailsFromDB = await this.commandExecutor.Execute(command);
            return new DeleteDetailsByIdResponse()
            {
                //Data = this.mapper.Map<Domain.Models.WarehauseDetail>(detailsFromDB)
                Data = detailsFromDB
            };
        }
    }
}