using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.WarehauseDetails
{
    public class GetWarehauseDetailQuery : QueryBase<WarehauseDetail>
    {
        public int Id { get; set; }
        public override async Task<WarehauseDetail> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.WarehauseDetails
                .Where(x => x.Id == this.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
