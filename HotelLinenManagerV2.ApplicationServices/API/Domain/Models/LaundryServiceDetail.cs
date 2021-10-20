using HotelLinenManagerV2.DataAccess.Entities;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class LaundryServiceDetail
    {
        public int Id { get; set; }
        public int LaundryServiceId { get; set; }
        public int HotelLinenId { get; set; }
        public int Amount { get; set; }
        public string HotelLinenName { get; set; }
        public Type HotelLinenType { get; set; }
        public string Color { get; set; }
        public decimal PricePerKg { get; set; }
        public double TotalWeight { get; set; }
        public int TaxValue { get; set; }
    }
}
