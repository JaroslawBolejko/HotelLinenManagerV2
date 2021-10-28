using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceLists
{
    public class GetPriceQuery : QueryBase<PriceList>
    {
        public int Id { get; set; }
        public override async Task<PriceList> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.PriceLists
                .Where(x => x.Id == this.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
