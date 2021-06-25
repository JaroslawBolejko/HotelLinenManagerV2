using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses
{
    public class DeleteWarehauseByIdRequest : RequestBase, IRequest<DeleteWarehauseByIdResponse>
    {
        public int Id { get; set; }
    }
}
