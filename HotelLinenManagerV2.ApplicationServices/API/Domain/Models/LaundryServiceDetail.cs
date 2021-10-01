namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class LaundryServiceDetail
    {
        public int Id { get; set; }
        public int LaundryServiceId { get; set; }
        public int HotelLinenId { get; set; }
        public int Amount { get; set; }
        public string HotelLinenName { get; set; }
        public string Color { get; set; }
    }
}
