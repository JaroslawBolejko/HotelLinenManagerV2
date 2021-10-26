using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails
{
    public class DeletePriceListDetailsRequest : RequestBase, IRequest<DeletePriceListDetailsResponse>
    {
        public int Id { get; set; }
    }
}
