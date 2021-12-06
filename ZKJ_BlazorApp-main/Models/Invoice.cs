using System;
using System.Collections.Generic;

namespace BlazorApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsPaid { get; set; }
        public List<LaundryService> LaundryServices { get; set; }
    }
}
