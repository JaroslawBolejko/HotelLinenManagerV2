using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceListDetails
{
    public class GetAllPriceListDetailsQuery : QueryBase<List<PriceListDetail>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<PriceListDetail>> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.PriceListDetails
                .Where(x => x.HotelLinen.CompanyId == this.CompanyId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
