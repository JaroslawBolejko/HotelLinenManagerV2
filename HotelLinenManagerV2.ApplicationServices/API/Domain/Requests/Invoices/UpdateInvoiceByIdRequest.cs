using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Invoices;
using MediatR;
using System;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices
{
    public class UpdateInvoiceByIdRequest : RequestBase, IRequest<UpdateInvoiceByIdResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsPaid { get; set; }
    }
}
