namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class HotelLinen
    {
        public int Id { get; set; }
        public string NameWithShortDescription { get; set; }
        public string Color { get; set; }
        public int HotelLinenTypeId { get; set; }
        public ushort Amount { get; set; }
        public int WarehauseId { get; set; }
       

    }
}

