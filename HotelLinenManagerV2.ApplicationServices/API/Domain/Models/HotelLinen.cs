using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class HotelLinen
    {
        public int Id { get; set; }
        public string NameWithShortDescription { get; set; }
        public string Color { get; set; }
        public int HotelLinenTypeId { get; set; }
        public ushort Amount { get; set; }
        public string TypeName { get; set; }
        public HotelLinenType HotelLinenType { get; set; }
        public List<WarehauseDetail> WarehauseDetails { get; set;}
       

    }
}

