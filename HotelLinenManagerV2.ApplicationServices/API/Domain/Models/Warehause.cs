using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{


    public class Warehause
    {
        public int Id { get; set; }
        public string WarehauseType { get; set; }
        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }
       // public int CompanyId { get; set; }
       // public List<string> LinenName { get; set; }
       // public List<int> LinenAmount { get; set; }
        public List<HotelLinen> HotelLinen { get; set; }
    }
}
