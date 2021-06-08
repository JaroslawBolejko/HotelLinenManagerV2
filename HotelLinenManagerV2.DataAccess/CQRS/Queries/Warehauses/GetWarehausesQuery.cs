using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Warehauses
{
    public class GetWarehausesQuery : QueryBase<List<Warehause>>
    {
        public int? WarehauseNumber { get; set; }
        public override async Task<List<Warehause>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if(this.WarehauseNumber!=null)
            {
                if (context.Warehauses.Any(x => x.WarehauseNumber == this.WarehauseNumber))
                {
                   
                    return await context.Warehauses.Where(x => x.WarehauseNumber == this.WarehauseNumber).ToListAsync();
                }
                return null;
            }
            var result = await context.Warehauses.ToListAsync();

            return result;
        }
    }
}
