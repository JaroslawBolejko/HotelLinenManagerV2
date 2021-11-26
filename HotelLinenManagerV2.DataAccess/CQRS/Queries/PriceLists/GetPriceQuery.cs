using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceLists
{
    public class GetPriceQuery : QueryBase<PriceList>
    {
        public int? Id { get; set; }
        public int? CompanyId { get; set; }
        public int? LaundryId { get; set; }
        public bool WouldLikeToCreate { get; set; }
        public override async Task<PriceList> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.Id != null)
            {
                return await context.PriceLists
                .Where(x => x.Id == this.Id)
                .Include(x => x.Details)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            }
            else if (this.LaundryId != null && this.CompanyId != null && this.WouldLikeToCreate == true)
            {
                return await context.PriceLists
                    .Where(x => x.CompanyId == this.CompanyId && x.LaundryId == this.LaundryId)
                    .OrderByDescending(x=>x.CreationDate)
                    .ThenBy(x=>x.Id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

            }
            else return null;
        }
    }
}
