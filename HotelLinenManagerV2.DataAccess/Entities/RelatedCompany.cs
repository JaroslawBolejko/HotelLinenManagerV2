using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class RelatedCompany : EntityBase
    {
        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        [ForeignKey("Laundry")]
        public int? LaundryId { get; set; }
        public Company Company { get; set; }
        public Company Laundry { get; set; }
    }
}
