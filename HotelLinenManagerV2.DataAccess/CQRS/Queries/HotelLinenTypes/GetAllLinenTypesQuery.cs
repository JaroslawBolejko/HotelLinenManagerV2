using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinenTypes
{
    public class GetAllLinenTypesQuery : QueryBase<List<HotelLinenType>>
    {
        public int? CompanyId { get; set; }
        public string Size { get; set; }
        public double? Weight { get; set; }
        public Type? TypeName { get; set; }
        public override async Task<List<HotelLinenType>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.CompanyId != null)
            {
                return await context.HotelLinenTypes
               .Include(x => x.HotelLinens)
               .AsNoTracking()
               .ToListAsync();
            }
            if(!string.IsNullOrEmpty(this.Size) && this.Weight!=null && this.TypeName!=null)
            {
                var result = await context.HotelLinenTypes
                    .Where(x => x.Size == this.Size && x.Weight == this.Weight && x.TypeName == this.TypeName)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            return null;

        }
    }
}
