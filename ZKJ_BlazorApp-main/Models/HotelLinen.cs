using System.Collections.Generic;

namespace BlazorApp.Models
{
    public class HotelLinen
    {
        public int Id { get; set; }
        public string NameWithShortDescription { get; set; }
        public string Color { get; set; }
        public int HotelLinenTypeId { get; set; }
        public ushort Amount { get; set; }
        public IEnumerable<WarehauseDetail> WarehauseDetails { get; set; }
        public int CompanyId { get; set; }

    }
}
