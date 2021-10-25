using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists
{
    public class UpdatePriceListByIdRequest : RequestBase,IRequest<UpdatePriceListByIdResponse>
    {
        public int Id { get; set; }
        public int LaundryId { get; set; }
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
    }
}
