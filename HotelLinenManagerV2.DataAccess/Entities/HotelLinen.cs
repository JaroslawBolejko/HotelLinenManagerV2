using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum Type
    {

        Cover = 1,
        Sheet = 2,
        Pillowcase = 3,
        Underlay = 4,
        Towel = 5,
        Duvel = 6,
        Pillow = 7,
        Coverlet = 8,
        Blanket = 9,
        Drape = 10,
        Curtain = 11,
        Cloth = 12,
        Napkin = 13

    }
    public class HotelLinen : EntityBase
    {
        [Required]
        public Type TypeName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Size { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public double Weight { get; set; }
        [Required]
        public bool IsUsed { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }
        [Required]
        [Range(0,10000)]
        public int Amount { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<WarehauseDetail> WarehauseDetails { get; set; }

    }


}
