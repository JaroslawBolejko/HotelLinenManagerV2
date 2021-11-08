using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails
{
    public class UpdatePriceListDetailsRequest : RequestBase,IRequest<UpdatePriceListDetailsResponse>
    {
        public int Id { get; set; }
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
        public int HotelLinenId { get; set; }
        public int PriceListId { get; set; }

    }
}
