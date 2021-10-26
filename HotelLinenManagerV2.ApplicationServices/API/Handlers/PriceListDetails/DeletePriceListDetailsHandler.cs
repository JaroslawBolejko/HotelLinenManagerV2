using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceListDetails;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceListDetails;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.PriceListDetails
{
    public class DeletePriceListDetailsHandler : IRequestHandler<DeletePriceListDetailsRequest, DeletePriceListDetailsResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeletePriceListDetailsHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeletePriceListDetailsResponse> Handle(DeletePriceListDetailsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPriceListDetailsQuery()
            {
                Id = request.Id
            };
            var prices = await this.queryExecutor.Execute(query);
            if (prices == null)
            {
                return new DeletePriceListDetailsResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPrices = this.mapper.Map<DataAccess.Entities.PriceListDetail>(request);
            var command = new DeletePriceListDetailsCommand()
            {
                Parameter = mappedPrices
            };
            var deletedPriceList = await this.commandExecutor.Execute(command);
            return new DeletePriceListDetailsResponse()
            {
                Data = deletedPriceList
            };
        }
    }
}
