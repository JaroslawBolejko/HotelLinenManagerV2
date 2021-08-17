using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices
{
    public class DeleteLaundryByIdRequest : RequestBase,IRequest<DeleteLaundryResponse>
    {
        public int Id { get; set; }
    }
}
