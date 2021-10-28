using System;

namespace BlazorApp.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int LaundryId { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Company Laundry { get; set; }
        public virtual Company Company { get; set; }
    }
}
