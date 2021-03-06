using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class PriceList : EntityBase
    {
        public string DocName { get; set; }
        public string DocNumber { get; set; }
        public int? LaundryId { get; set; }
        public int? CompanyId { get; set; }
        public bool IsCurrent { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }
        [ForeignKey("LaundryId")]
        public virtual Company Laundry { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company{ get; set; }
        public List<PriceListDetail> Details { get; set; }
    }
}

