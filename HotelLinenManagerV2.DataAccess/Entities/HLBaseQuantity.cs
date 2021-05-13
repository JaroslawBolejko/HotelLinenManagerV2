using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
   public  class HLBaseQuantity : EntityBase
    {
        [Required]
        public int HotelLinenId { get; set; }
        public HotelLinen HotelLinen { get; set; }
        [Required]
        public ushort HotelLinenBaseQuantity { get; set; }  
    }
}
