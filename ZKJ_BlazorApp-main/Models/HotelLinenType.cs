using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public enum Type : byte
    {
        // //[Display(Name = "Duvel Cover")]
        //  [Display(Name = "Poszwa")]
        // DuvelCover = 1,
        //// [Display(Name = "Sheet")]
        // [Display(Name = "Prześcieradło")]
        // Sheet = 2,
        //// [Display(Name = "Pillow Case")]
        // [Display(Name = "Poszewka")]
        // PillowCase = 3,
        // //[Display(Name = "Underlay")]
        // [Display(Name = "Podkład")]
        // Underlay = 4,
        // //[Display(Name = "Towel")]
        // [Display(Name = "Ręcaznik")]
        // Towel = 5,
        //// [Display(Name = "Foot Towel")]
        // [Display(Name = "Stopka")]
        // FootTowel = 6,
        // //[Display(Name = "Duvel")]
        // [Display(Name = "Pościel")]
        // Duvel = 7,
        //// [Display(Name = "Pillow")]
        // [Display(Name = "Poduszka")]
        // Pillow = 8,
        //// [Display(Name = "Coverlet")]
        // [Display(Name = "Kapa")]
        // Coverlet = 9,
        //// [Display(Name = "Blanket")]
        // [Display(Name = "Koc")]
        // Blanket = 10,
        // //[Display(Name = "Drape")]
        // [Display(Name = "Zasłona")]
        // Drape = 11,
        // //[Display(Name = "Curtain")]
        // [Display(Name = "Firanka")]
        // Curtain = 12,
        // //[Display(Name = "Table Cloth")]
        // [Display(Name = "Obrus")]
        // TableCloth = 13,
        //// [Display(Name = "Napkin")]
        // [Display(Name = "Serwetka")]
        // Napkin = 14
        Poszwa = 1,
        Prześcieradło = 2,
        Poszewka = 3,
        Podkład = 4,
        Ręcznik = 5,
        Stopka = 6,
        Kołdra = 7,
        Poduszka = 8,
        Kapa = 9,
        Koc = 10,
        Zasłona = 11,
        Firana = 12,
        Obrus = 13,
        Serwetka = 14
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
