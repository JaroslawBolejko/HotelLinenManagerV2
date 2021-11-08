using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails
{
    public class CreatePriceListDetailRequest : RequestBase, IRequest<CreatePriceListDetailResponse>
    {
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
        public int HotelLinenId { get; set; }
        public int PriceListId { get; set; }
    }
}
