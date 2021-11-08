using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails
{
    public class GetAllPriceListDetailsRequest : RequestBase,IRequest<GetAllPriceListDetailsResponse>
    {
        public int? PriceListId { get; set; }
    }
}
