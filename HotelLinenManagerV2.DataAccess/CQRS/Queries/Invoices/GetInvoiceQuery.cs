using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Invoices
{
    public class GetInvoiceQuery : QueryBase<Invoice>
    {
        public int? Id { get; set; }
        public string Number { get; set; }
        public override async Task<Invoice> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.Id != null)
            {
                return await context.Invoices.Where(x => x.Id == this.Id)
                    .Include(x => x.LaundryServices)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            else if (!string.IsNullOrEmpty(this.Number))
            {
                return await context.Invoices.Where(x => x.Number == this.Number)
                    .Include(x => x.LaundryServices)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            else return null;
        }
    }
}
