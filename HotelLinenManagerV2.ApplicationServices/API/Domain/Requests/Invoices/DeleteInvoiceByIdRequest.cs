using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Invoices;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices
{
    public class DeleteInvoiceByIdRequest : RequestBase, IRequest<DeleteInvoiceByIdResponse>
    {
        public int Id { get; set; }
    }
}
