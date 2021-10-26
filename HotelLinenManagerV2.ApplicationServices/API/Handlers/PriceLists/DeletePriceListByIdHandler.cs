using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceLists;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceLists;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.PriceLists
{
    public class DeletePriceListByIdHandler : IRequestHandler<DeletePriceListByIdRequest, DeletePriceListByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeletePriceListByIdHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
          

            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeletePriceListByIdResponse> Handle(DeletePriceListByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPriceQuery()
            {
                Id = request.Id
            };
            var prices = await this.queryExecutor.Execute(query);
            if (prices == null)
            {
                return new DeletePriceListByIdResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPrices = this.mapper.Map<DataAccess.Entities.PriceList>(request);
            var command = new DeletePriceListCommand()
            {
                Parameter = mappedPrices
            };
            var deletedPriceList = await this.commandExecutor.Execute(command);
            return new DeletePriceListByIdResponse()
            {
                Data = deletedPriceList
            };
        }
    }
}
