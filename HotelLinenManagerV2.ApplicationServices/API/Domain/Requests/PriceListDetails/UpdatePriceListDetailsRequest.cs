using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails
{
    public class UpdatePriceListDetailsRequest : RequestBase,IRequest<UpdatePriceListDetailsResponse>
    {
        public int Id { get; set; }
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
        public int PriceListId { get; set; }
        public Type? LinenType { get; set; }


    }
}
