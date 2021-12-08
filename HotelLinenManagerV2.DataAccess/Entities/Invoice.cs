using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        public int? CompanyId { get; set; }
        public int? LaundryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = "Faktura VAT";
        [Required]
        public string Number { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime DateOfInvoice { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }
        public decimal TotalCost { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        public List<LaundryService> LaundryServices { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        [ForeignKey("LaundryId")]
        public virtual Company Laundry { get; set; }
    }
}
