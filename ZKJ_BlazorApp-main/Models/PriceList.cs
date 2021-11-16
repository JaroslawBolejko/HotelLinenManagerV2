using System;
using System.Collections.Generic;

namespace BlazorApp.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int LaundryId { get; set; }
        public int CompanyId { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime CreationDate { get; set; }
        public Company Laundry { get; set; }
        public Company Company { get; set; }
        public List<PriceListDetail> Details { get; set; }
    }
}
