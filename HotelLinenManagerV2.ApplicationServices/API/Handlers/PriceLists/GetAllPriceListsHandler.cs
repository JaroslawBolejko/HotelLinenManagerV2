using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceLists;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.PriceLists
{
    public class GetAllPriceListsHandler : IRequestHandler<GetAllPriceListsRequest, GetAllPriceListsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllPriceListsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetAllPriceListsResponse> Handle(GetAllPriceListsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllPricesQuery()
            {
                LaundryId = request.LaundryId,
                CompanyId = request.AuthenticationCompanyId
            };
            var prices = await this.queryExecutor.Execute(query);
            //if (prices == null)
            //{
            //    return new GetAllPriceListsResponse()
            //    {
            //        Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
            //    };
            //}
            var mappedPrices = this.mapper.Map<List<PriceList>>(prices);
            return new GetAllPriceListsResponse()
            {
                Data = mappedPrices
            };
        }
    }
}
