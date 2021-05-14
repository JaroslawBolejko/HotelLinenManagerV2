
using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
   

    public  class Warehause
    {
        public int Id { get; set; }
        public string WarehauseType { get; set; }
        // public List<string> NameWithShortDescription { get; set; }
        // public List<int?> Amount {get;set;}
        public List<HotelLinen> HotelLinens { get; set; }
        public int? WarehauseNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
