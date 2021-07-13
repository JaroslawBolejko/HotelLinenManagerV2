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
        public int? WarehauseId { get; set; }
        public int? CompanyId { get; set; }
        public override async Task<List<HotelLinen>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.HotelLinenTypeId != null && !string.IsNullOrEmpty(this.NameWithShortDescription) && this.WarehauseId != null)
            {
                if (context.HotelLinens.Any(x => x.HotelLinenTypeId == this.HotelLinenTypeId
                    && x.NameWithShortDescription == this.NameWithShortDescription && x.WarehauseId == this.WarehauseId))
                {
                    return await context.HotelLinens.Where(x => x.HotelLinenTypeId == this.HotelLinenTypeId 
                    && x.HotelLinenTypeId == this.HotelLinenTypeId && x.WarehauseId == this.WarehauseId)
                    .ToListAsync();
                }
                return null;
            }

            if (this.HotelLinenTypeId == null && !string.IsNullOrEmpty(this.NameWithShortDescription) && this.WarehauseId ==null)
            {
                if (context.HotelLinens.Any(x => x.NameWithShortDescription == this.NameWithShortDescription))
                {
                    return await context.HotelLinens.Where(x => x.NameWithShortDescription == this.NameWithShortDescription).ToListAsync();
                }
                return null;
            }

            if (this.HotelLinenTypeId != null && string.IsNullOrEmpty(this.NameWithShortDescription) && this.WarehauseId == null)
            {
                if (context.HotelLinens.Any(x => x.HotelLinenTypeId == this.HotelLinenTypeId))
                {
                    return await context.HotelLinens.Where(x => x.HotelLinenTypeId == this.HotelLinenTypeId).ToListAsync();
                }
                return null;
            }
            if (this.HotelLinenTypeId == null && string.IsNullOrEmpty(this.NameWithShortDescription) && this.WarehauseId != null)
            {
                if (context.HotelLinens.Any(x => x.WarehauseId == this.WarehauseId))
                {
                    return await context.HotelLinens.Where(x => x.WarehauseId == this.WarehauseId).ToListAsync();
                }
                return null;
            }
            //if(this.CompanyId != null)
            //{
            //    return await context.HotelLinens
            //        .Include(x=>x.Warhause.)
            //}

            else
            {
                return await context.HotelLinens.ToListAsync();

            }
        }
    }
}
