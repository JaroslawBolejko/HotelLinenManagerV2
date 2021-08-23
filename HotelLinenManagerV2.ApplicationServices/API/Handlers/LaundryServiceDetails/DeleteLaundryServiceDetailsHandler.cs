using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServiceDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.LaundryServiceDetails;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServiceDetails;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.LaundryServiceDetails
{
    public class DeleteLaundryServiceDetailsHandler : IRequestHandler<DeleteLaundryDetailsByIdRequest, DeleteLaundryDetailsByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeleteLaundryServiceDetailsHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteLaundryDetailsByIdResponse> Handle(DeleteLaundryDetailsByIdRequest request, CancellationToken cancellationToken)
        {
           

            var query = new GetLaundryDetailsQuery()
            {
                Id = request.Id
            };

            var details = await this.queryExecutor.Execute(query);

            if (details == null)
            {
                return new DeleteLaundryDetailsByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDetails = this.mapper.Map<DataAccess.Entities.LaundryServiceDetail>(request);
            var command = new DeleteLaundryDetailCommand()
            {
                Parameter = mappedDetails
            };

            var detailsFromDB = await this.commandExecutor.Execute(command);
            return new DeleteLaundryDetailsByIdResponse()
            {
                Data = detailsFromDB
            };
        }
    }
}