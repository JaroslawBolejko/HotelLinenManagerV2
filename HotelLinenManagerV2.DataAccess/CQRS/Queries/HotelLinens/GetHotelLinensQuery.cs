using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens
{
    public class GetHotelLinensQuery : QueryBase<List<HotelLinen>>
    {

        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public int? WarehauseId { get; set; }

        public override async Task<List<HotelLinen>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (!string.IsNullOrEmpty(this.Description))
            {
                if (context.HotelLinens.Any(x => x.Description == this.Description))
                {
                    return await context.HotelLinens
                        .Where(x => x.Description == this.Description)
                        .Include(x => x.Company)
                        .AsNoTracking()
                        .ToListAsync();
                }
                return null;
            }


            if (this.CompanyId != null && this.WarehauseId == null)
            {
                return await context.HotelLinens
                         .Where(x => x.Company.Id == this.CompanyId)
                         .Include(x => x.Company)
                         .AsNoTracking()
                         .ToListAsync();
            }
            if (this.CompanyId != null && this.WarehauseId != null)
            {
                var result = await context.WarehauseDetails.Join(context.HotelLinens, warehausedetail => warehausedetail.HotelLinenId, hotellinen => hotellinen.Id,
                    (warehausedetail, hotellinen) => new
                    {
                        Id = hotellinen.Id,
                        WarehauseId = warehausedetail.WarehauseId,
                        HotelLinenName = hotellinen.Description
                    }).ToListAsync();

                List<HotelLinen> returnList = new();
                var result2 = result.Where(x => x.WarehauseId == this.WarehauseId).Select(x => x.Id).Distinct().ToList();
                for (int i = 0; i < result2.Count; i++)
                {
                    var item = await context.HotelLinens
                        .Where(x => x.Id == result2[i])
                        .Include(x => x.Company)
                        .AsNoTracking()
                        .ToListAsync();
                    if (item != null) returnList.AddRange(item);
                }
                return returnList;
            }
            else
            {
                return await context.HotelLinens
                    .Include(x => x.Company)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
