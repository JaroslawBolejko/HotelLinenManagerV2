using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens
{
    public class GetHotelLinenQuery : QueryBase<HotelLinen>
    {
        public int Id { get; set; }

        public override async Task<HotelLinen> Execute(WarehauseStorageHotelLinenContext context)
        {
            var result = await context.HotelLinens
                .Include(x=>x.Company)
                .Include(y=>y.PriceListDetails)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == this.Id);
            return result;
        }
    }
}
