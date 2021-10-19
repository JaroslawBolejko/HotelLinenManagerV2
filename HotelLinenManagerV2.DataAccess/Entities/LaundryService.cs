using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class LaundryService : EntityBase
    {
        [Required]
        public int? CompanyId { get; set; }
        public int? LaundryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(150)]
        public string Number { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime RecievedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? IssuedDate { get; set; }
        public bool IsFinished { get; set; }
        public List<LaundryServiceDetail> LaundryServiceDetails { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        [ForeignKey("LaundryId")]
        public virtual Company Laundry { get; set; }
    }
}
