using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Warehauses
{
    public class GetWarehausesQuery : QueryBase<List<Warehause>>
    {
        public override async Task<List<Warehause>> Execute(WarehauseStorageHotelLinenContext context)
        {
            var result = await context.Warehauses.ToListAsync();

            return result;
        }
    }
}
