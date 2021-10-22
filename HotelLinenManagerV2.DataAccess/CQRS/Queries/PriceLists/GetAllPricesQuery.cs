using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceLists
{
    public class GetAllPricesQuery : QueryBase<List<PriceList>>
    {
        public override async  Task<List<PriceList>> Execute(WarehauseStorageHotelLinenContext context)
        {

            return await context.PriceLists.ToListAsync();

        }
    }
}
