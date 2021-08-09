namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class WarehauseDetail
    {
        public int Id { get; set; }
        public int HotelLinenId { get; set; }
        public int WarehauseId { get; set; }
        public ushort Amount { get; set; }

    }
}
