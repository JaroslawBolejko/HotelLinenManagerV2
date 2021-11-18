using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceListDetails
{
    public class GetPriceListDetailsQuery : QueryBase<PriceListDetail>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public override async Task<PriceListDetail> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.PriceListDetails
                .Where(x => x.Id == this.Id && x.PriceList.CompanyId == this.CompanyId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        }
    }
}
