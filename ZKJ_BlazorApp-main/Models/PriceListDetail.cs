namespace BlazorApp.Models
{
    public class PriceListDetail
    {
        public int Id { get; set; }
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
        public int PriceListId { get; set; }
        public Type LinenType { get; set; }
        public PriceList PriceList { get; set; }
    }
}
