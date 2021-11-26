using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceListDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.PriceListDetails
{
    public class GetAllPriceListDetailsHandler : IRequestHandler<GetAllPriceListDetailsRequest, GetAllPriceListDetailsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllPriceListDetailsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetAllPriceListDetailsResponse> Handle(GetAllPriceListDetailsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllPriceListDetailsQuery()
            {
                PriceListId = request.PriceListId,
                CompanyId = request.AuthenticationCompanyId,
                LinenType = request.LinenType
            };
            var prices = await this.queryExecutor.Execute(query);

            var mappedPrices = this.mapper.Map<List<Domain.Models.PriceListDetail>>(prices);
            return new GetAllPriceListDetailsResponse()
            {
                Data = mappedPrices
            };
        }
    }
}
