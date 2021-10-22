using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Invoices
{
   public class GetAllInvoicesQuery : QueryBase<List<Invoice>>
    {
        public int CompanyId { get; set; }
       
        public override async Task<List<Invoice>> Execute(WarehauseStorageHotelLinenContext context)
        {
            //(x => x.LaundryServices.Select(y => y.CompanyId).FirstOrDefault() == this.CompanyId)
            return await context.Invoices.Where(x => x.LaundryServices.Select(y => y.CompanyId).FirstOrDefault() == this.CompanyId)
                .Include(x=>x.LaundryServices)
                .AsNoTracking()
                .ToListAsync();
                
        }
    }
}
