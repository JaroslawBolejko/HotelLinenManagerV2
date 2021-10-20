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

            return await context.Invoices
                .Include(x=>x.LaundryServices.Where(x=>x.LaundryId==this.CompanyId || x.CompanyId==this.CompanyId))
                .AsNoTracking()
                .ToListAsync();
                
        }
    }
}
