using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinenTypes
{
    public class GetAllLinenTypesQuery : QueryBase<List<HotelLinenType>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<HotelLinenType>> Execute(WarehauseStorageHotelLinenContext context)
        {
            //Zrób joina
            return await context.HotelLinenTypes
                .Include(x => x.HotelLinens)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
