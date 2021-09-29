using System.Collections.Generic;

namespace BlazorApp.Models
{
    public enum Type
    {
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
    public class HotelLinen
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public ushort Amount { get; set; }
        public Type TypeName { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public decimal PricePerKg { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int WarehauseId {get;set;}
        public Warehause Warehause { get; set; }
        public IEnumerable<WarehauseDetail> WarehauseDetails { get; set; }

    }
}
