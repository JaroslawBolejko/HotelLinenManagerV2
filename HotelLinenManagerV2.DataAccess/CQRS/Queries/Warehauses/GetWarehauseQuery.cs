using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Warehauses
{
    public class GetWarehauseQuery : QueryBase<Warehause>
    {
        public int Id { get; set; }
        public override async Task<Warehause> Execute(WarehauseStorageHotelLinenContext context)
        {

            return await context.Warehauses.Where(x => x.Id == this.Id)
                .Include(x => x.WarehauseDetails)
                .FirstOrDefaultAsync();
        }
    }
}
