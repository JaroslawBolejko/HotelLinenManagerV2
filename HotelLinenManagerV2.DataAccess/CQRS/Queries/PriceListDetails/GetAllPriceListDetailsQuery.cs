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
        public int? PriceListId { get; set; }
        public override async Task<List<PriceListDetail>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if(this.PriceListId != null)
            {
                return await context.PriceListDetails
                    .Where(x => x.PriceListId == this.PriceListId)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                return await context.PriceListDetails
                                .Where(x => x.HotelLinen.CompanyId == this.CompanyId)
                                .AsNoTracking()
                                .ToListAsync();
            }
            
        }
    }
}
