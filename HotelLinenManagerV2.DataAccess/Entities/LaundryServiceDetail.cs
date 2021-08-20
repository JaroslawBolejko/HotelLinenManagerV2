namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class LaundryServiceDetail : EntityBase

    {
        public int LaundryServiceId { get; set; }
        public int HotelLinenId { get; set; }
        public ushort Amount { get; set; }
        public LaundryService LaundryService { get; set; }
        public HotelLinen HotelLinen { get; set; }
    }
}
