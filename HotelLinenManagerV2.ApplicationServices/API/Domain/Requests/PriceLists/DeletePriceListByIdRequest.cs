using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists
{
    public class DeletePriceListByIdRequest :RequestBase,IRequest<DeletePriceListByIdResponse>
    {
        public int Id { get; set; }
    }
}
