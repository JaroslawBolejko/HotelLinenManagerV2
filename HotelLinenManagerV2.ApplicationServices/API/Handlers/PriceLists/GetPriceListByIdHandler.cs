using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceLists;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.PriceLists
{
    public class GetPriceListByIdHandler : IRequestHandler<GetPriceListByIdRequest, GetPriceListByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetPriceListByIdHandler(IQueryExecutor queryExecutor,IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetPriceListByIdResponse> Handle(GetPriceListByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPriceQuery()
            {
                Id = request.Id
            };
            var prices = await this.queryExecutor.Execute(query);
            if (prices == null)
            {
                return new GetPriceListByIdResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPrices = this.mapper.Map<PriceList>(prices);
            return new GetPriceListByIdResponse()
            {
                Data = mappedPrices
            };


        }
    }
}
