using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens
{
    public class GetHotelLinensQuery : QueryBase<List<HotelLinen>>
    {
        public override async Task<List<HotelLinen>> Execute(WarehauseStorageHotelLinenContext context)
        {
            var result = await context.HotelLinens.ToListAsync();
            return result;

        }
    }
}
