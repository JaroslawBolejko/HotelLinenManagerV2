using System;
using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal? TotalCost { get; set; }
        public bool IsPaid { get; set; }
        public int CompanyId { get; set; }
        public int LaundryId { get; set; }
        public List<LaundryService> LaundryServices { get; set; }
        public Company Company { get; set; }
        public Company Laundry { get; set; }
    }
}
