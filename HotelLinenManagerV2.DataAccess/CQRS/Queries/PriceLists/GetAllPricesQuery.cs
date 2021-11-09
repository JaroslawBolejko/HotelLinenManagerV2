using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceLists
{
    public class GetAllPricesQuery : QueryBase<List<PriceList>>
    {
        public int LaundryId { get; set; }
        public int CompanyId { get; set; }
        public override async Task<List<PriceList>> Execute(WarehauseStorageHotelLinenContext context)
        {

            var result = await context.PriceLists
                .Where(x => x.CompanyId == this.CompanyId && x.LaundryId==this.LaundryId)
                .Include(x=>x.Company)
                .Include(x=>x.Laundry)
                .AsNoTracking()
                .ToListAsync();
            if (result.Count == 0) return null;
            return result;

        }
    }
}
