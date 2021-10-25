using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists
{
    public class GetAllPriceListsRequest : RequestBase,IRequest<GetAllPriceListsResponse>
    {

    }
}
