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
        public string UserRole { get; set; }


        public override async Task<List<Invoice>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if(UserRole=="UserLaundry")
            {
                return await context.Invoices.Where(y => y.LaundryId == this.CompanyId)
                    .Include(x => x.LaundryServices)
                    .Include(x => x.Company)
                    .Include(x => x.Laundry)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                return await context.Invoices.Where(y => y.CompanyId == this.CompanyId)
               .Include(x => x.LaundryServices)
               .Include(x => x.Company)
               .Include(x => x.Laundry)
               .AsNoTracking()
               .ToListAsync();
            }
           
                
        }
    }
}
