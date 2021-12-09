using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Invoices
{
    public class GetInvoiceQuery : QueryBase<Invoice>
    {
        public int? Id { get; set; }
        public int? CompanyId { get; set; }
        public int? LaundryId { get; set; }
        public string Number { get; set; }
        public bool WouldLikeToCreate { get; set; }
 
        public override async Task<Invoice> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.Id != null)
            {
                return await context.Invoices.Where(x => x.Id == this.Id)
                    .Include(x => x.LaundryServices)
                    .Include(x => x.Company)
                    .Include(x => x.Laundry)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            else if (!string.IsNullOrEmpty(this.Number))
            {
                return await context.Invoices.Where(x => x.Number == this.Number)
                    .Include(x => x.LaundryServices)
                    .Include(x => x.Company)
                    .Include(x => x.Laundry)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            else if (this.WouldLikeToCreate == true && this.CompanyId!=null && this.LaundryId!=null)
            {
              
                return await context.Invoices
                    .Where(y => y.CompanyId == this.CompanyId && y.LaundryId == this.LaundryId)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync();

            }
            else return null;
        }
    }
}
