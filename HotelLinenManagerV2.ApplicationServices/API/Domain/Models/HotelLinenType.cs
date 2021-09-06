using HotelLinenManagerV2.DataAccess.Entities;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class HotelLinenType
    {
        public Type TypeName { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal Tax { get; set; }
    }
}

