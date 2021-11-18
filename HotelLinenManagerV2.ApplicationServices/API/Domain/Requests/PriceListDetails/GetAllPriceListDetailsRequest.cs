using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails
{
    public class GetAllPriceListDetailsRequest : RequestBase,IRequest<GetAllPriceListDetailsResponse>
    {
        public int? PriceListId { get; set; }
        public Type? LinenType { get; set; }
    }
}
