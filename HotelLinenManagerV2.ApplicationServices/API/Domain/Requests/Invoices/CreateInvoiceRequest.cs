using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Invoices;
using MediatR;
using System;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices
{
    public class CreateInvoiceRequest : RequestBase, IRequest<CreateRequestResponse>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsPaid { get; set; }
    }
}
