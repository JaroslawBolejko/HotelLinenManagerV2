using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServices
{
    public class GetLaundryQuery : QueryBase<LaundryService>
    {
        public int? Id { get; set; }
        public int? CompanyId { get; set; }
        public bool WouldLikeToCreate { get; set; }
        public override async Task<LaundryService> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.Id != null)
            {
                return await context.LaundryServices
                    .Where(x => x.Id == this.Id)
                    .Include(x => x.Company)
                    .Include(x => x.Laundry)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            else if (this.CompanyId != null && this.WouldLikeToCreate == true)
            {
                return await context.LaundryServices
                    .AsNoTracking()
                    .OrderByDescending(x=>x.RecievedDate)
                    .ThenByDescending(x=>x.Id)
                    .LastOrDefaultAsync();
            }
            else return null;
        }
    }
}
