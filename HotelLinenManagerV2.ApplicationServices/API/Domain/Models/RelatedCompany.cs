namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class RelatedCompany
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LaundryId { get; set; }
        public Company Company { get; set; }
        public Company Laundry { get; set; }
    }
}
