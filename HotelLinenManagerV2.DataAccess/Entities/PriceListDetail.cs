namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class PriceListDetail : EntityBase
    {
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
        public int HotelLinenId {get;set;}
        public HotelLinen HotelLinen { get; set; }

    }
}
