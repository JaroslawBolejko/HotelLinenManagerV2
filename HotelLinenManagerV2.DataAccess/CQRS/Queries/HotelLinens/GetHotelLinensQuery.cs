using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens
{
    public class GetHotelLinensQuery : QueryBase<List<HotelLinen>>
    {
        public int? HotelLinenTypeId { get; set; }
        public string NameWithShortDescription { get; set; }
        public int? CompanyId { get; set; }
        public int? WarehauseId { get; set; }

        public override async Task<List<HotelLinen>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.HotelLinenTypeId != null && !string.IsNullOrEmpty(this.NameWithShortDescription))
            {
                if (context.HotelLinens.Any(x => x.HotelLinenTypeId == this.HotelLinenTypeId
                    && x.NameWithShortDescription == this.NameWithShortDescription))
                {
                    return await context.HotelLinens.Where(x => x.HotelLinenTypeId == this.HotelLinenTypeId
                    && x.HotelLinenTypeId == this.HotelLinenTypeId)
                    .ToListAsync();
                }
                return null;
            }

            if (this.HotelLinenTypeId == null && !string.IsNullOrEmpty(this.NameWithShortDescription))
            {
                if (context.HotelLinens.Any(x => x.NameWithShortDescription == this.NameWithShortDescription))
                {
                    return await context.HotelLinens.Where(x => x.NameWithShortDescription == this.NameWithShortDescription).ToListAsync();
                }
                return null;
            }

            if (this.HotelLinenTypeId != null && string.IsNullOrEmpty(this.NameWithShortDescription))
            {
                if (context.HotelLinens.Any(x => x.HotelLinenTypeId == this.HotelLinenTypeId))
                {
                    return await context.HotelLinens.Where(x => x.HotelLinenTypeId == this.HotelLinenTypeId).ToListAsync();
                }
                return null;
            }

            if (this.CompanyId != null && this.WarehauseId==null)
            {
                var result = await context.WarehauseDetails.Join(context.HotelLinens, warehausedetail => warehausedetail.HotelLinenId, hotellinen => hotellinen.Id,
                    (warehausedetail, hotellinen) => new
                    {
                        Id = hotellinen.Id,
                        WarehauseId = warehausedetail.WarehauseId
                    }).Join(context.Warehauses, warerhauseDet => warerhauseDet.WarehauseId, warehause => warehause.Id, (warehauseDet, warehause) => new
                    {
                        LinenId = warehauseDet.Id,
                        CompanyId = warehause.CompanyId
                    }).ToListAsync();

                List<HotelLinen> returnList = new();
                var result2 = result.Where(x => x.CompanyId == this.CompanyId).Select(x => x.LinenId).Distinct().ToList();
                for (int i = 0; i < result2.Count; i++)
                {
                    var item = await context.HotelLinens.Where(x => x.Id == result2[i]).ToListAsync();
                    if (item != null) returnList.AddRange(item);
                }
                return returnList;
            }
            if (this.CompanyId != null && this.WarehauseId != null)
            {
                var result = await context.WarehauseDetails.Join(context.HotelLinens, warehausedetail => warehausedetail.HotelLinenId, hotellinen => hotellinen.Id,
                    (warehausedetail, hotellinen) => new
                    {
                        Id = hotellinen.Id,
                        WarehauseId = warehausedetail.WarehauseId,
                        HotelLinenName =  hotellinen.NameWithShortDescription
                    }).ToListAsync();

                List<HotelLinen> returnList = new();
                var result2 = result.Where(x => x.WarehauseId == this.WarehauseId).Select(x => x.Id).Distinct().ToList();
                for (int i = 0; i < result2.Count; i++)
                {
                    var item = await context.HotelLinens.Where(x => x.Id == result2[i]).ToListAsync();
                    if (item != null) returnList.AddRange(item);
                }
                return returnList;
            }
            else
            {
                return await context.HotelLinens.ToListAsync();
            }
        }
    }
}
