using HotelLinenManagerV2.DataAccess.Entities;
using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{


    public class Warehause
    {
        public int Id { get; set; }
        public WarehauseType WarehauseType { get; set; }
        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }
        public List<HotelLinen> HotelLinen { get; set; }
    }
}
