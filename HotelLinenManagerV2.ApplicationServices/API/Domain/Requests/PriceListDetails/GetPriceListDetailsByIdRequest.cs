using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails
{
    public class GetPriceListDetailsByIdRequest : RequestBase,IRequest<GetPriceListDetailsByIdResponse>
    {
        public int Id { get; set; }
    }
}
