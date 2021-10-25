using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        public int LaundryId { get; set; }
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }
        public Company Laundry { get; set; }
    }
}
