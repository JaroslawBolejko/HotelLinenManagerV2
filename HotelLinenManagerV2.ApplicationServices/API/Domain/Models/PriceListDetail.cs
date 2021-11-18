using HotelLinenManagerV2.DataAccess.Entities;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
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
