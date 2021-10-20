using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Invoices
{
    public class GetInvoiceQuery : QueryBase<Invoice>
    {
        public int Id { get; set; }
        public override async Task<Invoice> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.Invoices.Where(x=>x.Id == this.Id)
                .Include(x=>x.LaundryServices)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        }
    }
}
