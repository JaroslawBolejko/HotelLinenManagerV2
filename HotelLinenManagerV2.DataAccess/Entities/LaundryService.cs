using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class LaundryService : EntityBase
    {
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
        [Required]
        public bool IsFinished { get; set; }
        [Required]
        public decimal TotalTax { get; set; }
        [Required]
        public decimal TotalNetto { get; set; }
        [Required]
        public decimal TotalBrutto { get; set; }
        public int? InvoiceId { get; set; }
        public List<LaundryServiceDetail> LaundryServiceDetails { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        [ForeignKey("LaundryId")]
        public virtual Company Laundry { get; set; }
        public Invoice Invoice { get; set; }
    }
}
