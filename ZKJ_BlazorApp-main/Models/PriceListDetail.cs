namespace BlazorApp.Models
{
    public class PriceListDetail
    {
        public int Id { get; set; }
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
        public int HotelLinenId { get; set; }
        public HotelLinen HotelLinen { get; set; }
    }
}
