using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class HotelLinenType : EntityBase
    {
        [Required]
        [MaxLength(80)]
        public string TypeName { get; set; }
       
        [Required]
        [MaxLength(50)]
        public string Size { get; set; }
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public double Weight { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public decimal PricePerKg { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public decimal Tax { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }
    }
}

