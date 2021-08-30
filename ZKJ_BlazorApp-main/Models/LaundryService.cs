using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class LaundryService
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime RecievedDate { get; set; }
        public DateTime? IssuedDate { get;set; }
        public bool IsFinished { get; set; }
        public List<LaundryServiceDetail> LaundryServiceDetails { get; set; }

       

    }
}
