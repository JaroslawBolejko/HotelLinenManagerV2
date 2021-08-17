using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServiceDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails

{
    public class DeleteLaundryDetailsByIdRequest : RequestBase,IRequest<DeleteLaundryDetailsByIdResponse>
    {
        public int Id { get; set; }
    }
}
