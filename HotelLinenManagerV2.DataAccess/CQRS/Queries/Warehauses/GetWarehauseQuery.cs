using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Warehauses
{
    public class GetWarehauseQuery : QueryBase<Warehause>
    {
        public int Id { get; set; }
        public override async Task<Warehause> Execute(WarehauseStorageHotelLinenContext context)
        {
            var result = await context.Warehauses.FirstOrDefaultAsync(x => x.Id == this.Id);

            return result;

        }
    }
}
