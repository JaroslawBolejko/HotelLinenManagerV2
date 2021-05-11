using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class HotelLinen : EntityBase
    {

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public short Amount { get; set; }
        [Required]
        [MaxLength(250)]
        public string Type { get; set; }
        [Required]
        [MaxLength(250)]
        public string Size { get; set; }
        [Required]
        [MaxLength(250)]
        public string Color { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public double Weight { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public decimal PricePerKg { get; set; }
        [Required]
        [Column(TypeName = "varchar(2)")]
        public byte Tax { get; set; }
    }
}
