using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
  
    public class Warehause : EntityBase
    {
      
        public HotelLinen HotelLinen { get; set; }
        public int HotelLinenAmount { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
