using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceLists
{
    public class GetAllPricesQuery : QueryBase<List<PriceList>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<PriceList>> Execute(WarehauseStorageHotelLinenContext context)
        {

            var response = await context.PriceLists
                .Where(x => x.CompanyId == this.CompanyId)
                .ToListAsync();
            if (response.Count == 0) return null;
            return response;

        }
    }
}
