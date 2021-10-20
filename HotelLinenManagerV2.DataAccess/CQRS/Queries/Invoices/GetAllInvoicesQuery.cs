using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Invoices
{
   public class GetAllInvoicesQuery : QueryBase<List<Invoice>>
    {
        public override async Task<List<Invoice>> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.Invoices
                .AsNoTracking()
                .Include(x=>x.LaundryServices)
                .ToListAsync();
                
        }
    }
}
