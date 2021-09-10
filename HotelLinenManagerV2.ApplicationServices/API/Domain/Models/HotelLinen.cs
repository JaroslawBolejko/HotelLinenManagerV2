using HotelLinenManagerV2.DataAccess.Entities;
using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class HotelLinen
    {
        public int Id { get; set; }
        public Type TypeName { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public decimal PricePerKg { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public ushort Amount { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<WarehauseDetail> WarehauseDetails { get; set; }



    }
}

