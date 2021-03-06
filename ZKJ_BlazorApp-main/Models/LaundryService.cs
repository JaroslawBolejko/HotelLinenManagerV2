using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class LaundryService
    {
        public int Id { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int LaundryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Number { get; set; }
        [Required]
        [DataType(DataType.DateTime,ErrorMessage ="It's not a proper date format")]
        public DateTime RecievedDate { get; set; }
        public DateTime? IssuedDate { get; set; }
        public bool IsFinished { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalNetto { get; set; }
        public decimal TotalBrutto { get; set; }
        public double TotalServiceWeight { get; set; }
        public int? InvoiceId { get; set; }
        public List<LaundryServiceDetail> LaundryServiceDetails { get; set; }
        public Company Company { get; set; }
        public Company Laundry { get; set; }

        //decimal.Round(yourValue, 2, MidpointRounding.AwayFromZero) W razie w;


    }
}
