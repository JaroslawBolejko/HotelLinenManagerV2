using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceListDetails;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.PriceListDetails
{
    public class GetPriceListDetailsByIdHandler : IRequestHandler<GetPriceListDetailsByIdRequest, GetPriceListDetailsByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetPriceListDetailsByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetPriceListDetailsByIdResponse> Handle(GetPriceListDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPriceListDetailsQuery()
            {
                Id = request.Id,
                CompanyId = request.AuthenticationCompanyId
            };
            var prices = await this.queryExecutor.Execute(query);
            if (prices == null)
            {
                return new GetPriceListDetailsByIdResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPrices = this.mapper.Map<PriceListDetail>(prices);
            return new GetPriceListDetailsByIdResponse()
            {
                Data = mappedPrices
            };
        }
    }
}
