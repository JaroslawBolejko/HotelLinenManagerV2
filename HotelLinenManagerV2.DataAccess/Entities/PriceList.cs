using System.Collections.Generic;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class PriceList : EntityBase
    {
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }
    }
}
