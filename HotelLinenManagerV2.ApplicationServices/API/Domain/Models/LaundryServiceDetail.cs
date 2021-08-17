namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class LaundryServiceDetail
    {
        public int Id { get; set; }
        public int LaundryServiceId { get; set; }
        public int HotelLinenId { get; set; }
        public ushort Amount { get; set; }
        public LaundryService LaundryService { get; set; }
        public HotelLinen HotelLinen { get; set; }
    }
}
