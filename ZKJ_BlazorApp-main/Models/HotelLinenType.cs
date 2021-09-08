using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public enum Type : byte
    {
        [Display(Name = "Duvel Cover")]
        DuvelCover = 1,
        [Display(Name = "Sheet")]
        Sheet = 2,
        [Display(Name = "Pillow Case")]
        PillowCase = 3,
        [Display(Name = "Underlay")]
        Underlay = 4,
        [Display(Name = "Towel")]
        Towel = 5,
        [Display(Name = "Foot Towel")]
        FootTowel = 6,
        [Display(Name = "Duvel")]
        Duvel = 7,
        [Display(Name = "Pillow")]
        Pillow = 8,
        [Display(Name = "Coverlet")]
        Coverlet = 9,
        [Display(Name = "Blanket")]
        Blanket = 10,
        [Display(Name = "Drape")]
        Drape = 11,
        [Display(Name = "Curtain")]
        Curtain = 12,
        [Display(Name = "Table Cloth")]
        TableCloth = 13,
        [Display(Name = "Napkin")]
        Napkin = 14

    }
    public class HotelLinenType
    {
        public int Id { get; set; }
        public Type TypeName { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal Tax { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }

    }
}
