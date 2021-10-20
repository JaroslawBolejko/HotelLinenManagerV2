using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        
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
        [Required]
        public decimal TotalCost { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        public List<LaundryService> LaundryServices { get; set; }
    }
}
