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
        public int? CompanyId { get; set; }
        public override async Task<List<WarehauseDetail>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.WarehauseId != null && this.HotelLinenId != null)
            {
                var result = await context.WarehauseDetails
                    .Where(x => x.HotelLinenId == this.HotelLinenId && x.WarehauseId == this.WarehauseId)
                    .Include(x => x.HotelLinen)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0) return null;
                return result;
            }
            else if (this.WarehauseId != null && this.HotelLinenId == null)
            {
                var result = await context.WarehauseDetails
                    .Where(x => x.WarehauseId == this.WarehauseId)
                    .Include(x => x.HotelLinen)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0) return null;
                return result;

            }
            else if (this.WarehauseId == null && this.HotelLinenId != null)
            {
                var result = await context.WarehauseDetails
                    .Where(x => x.HotelLinenId == this.HotelLinenId)
                    .Include(x => x.HotelLinen)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0) return null;
                return result;

            }
            else if (this.CompanyId != null)
            {
                var result = await context.WarehauseDetails
                    .Join(context.Warehauses, warerhauseDet => warerhauseDet.WarehauseId, warehause => warehause.Id, (warehauseDet, warehause)
                    => new
                    {
                        DetailId = warehauseDet.Id,
                        CompanyId = warehause.CompanyId
                    })
                    .AsNoTracking()
                    .ToListAsync();

                List<WarehauseDetail> returnList = new();
                var result2 = result.Where(x => x.CompanyId == this.CompanyId).Select(x => x.DetailId).Distinct().ToList();
                for (int i = 0; i < result2.Count; i++)
                {
                    var item = await context.WarehauseDetails
                                               .Where(x => x.Id == result2[i])
                                               .Include(x=>x.HotelLinen)
                                               .AsNoTracking()
                                               .ToListAsync();
                    if (item != null) returnList.AddRange(item);
                }
                return returnList;
            }
            else
            {
                return null;
            }
        }
    }
}
