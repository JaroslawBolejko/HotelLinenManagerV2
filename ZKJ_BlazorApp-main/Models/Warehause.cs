using System.Collections.Generic;

namespace BlazorApp.Models
{
    public enum WarehauseType
    {
        CleanLinenWarehause = 0,
        DirtyLinenWarehause = 1,
        Room = 2
    }
    public class Warehause
    {
        public int Id { get; set; }
        public WarehauseType WarehauseType { get; set; }
        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }
        public int? CompanyId { get; set; }
        public List<HotelLinen> HotelLinen { get; set; }
        
    }
}
