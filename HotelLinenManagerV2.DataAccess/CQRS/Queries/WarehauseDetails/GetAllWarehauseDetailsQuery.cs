using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.WarehauseDetails
{
    public class GetAllWarehauseDetailsQuery : QueryBase<List<WarehauseDetail>>
    {
        public int? HotelLinenId { get; set; }
        public int? WarehauseId { get; set; }
        public override async Task<List<WarehauseDetail>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.WarehauseId != null && this.HotelLinenId != null)
            {
                return await context.WarehauseDetails.Where(x => x.HotelLinenId == this.HotelLinenId && x.WarehauseId == this.WarehauseId).ToListAsync();
            }
            return await context.WarehauseDetails.ToListAsync();
        }
    }
}
