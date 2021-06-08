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
        public override async Task<List<HotelLinen>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.HotelLinenTypeId != null && !string.IsNullOrEmpty(this.NameWithShortDescription))
            {
                if (context.HotelLinens.Any(x => x.HotelLinenTypeId == this.HotelLinenTypeId
                    && x.NameWithShortDescription == this.NameWithShortDescription))
                {
                    return await context.HotelLinens.Where(x => x.HotelLinenTypeId == this.HotelLinenTypeId && x.HotelLinenTypeId == this.HotelLinenTypeId).ToListAsync();
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
            else
            {
                return await context.HotelLinens.ToListAsync();

            }
        }
    }
}
