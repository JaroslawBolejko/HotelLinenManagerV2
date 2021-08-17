using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServiceDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails
{
    public class GetLaundryDetailsByIdRequest : RequestBase,IRequest<GetLaundryDetailsByIdResponse>
    {
        public int Id { get; set; }
    }
}
