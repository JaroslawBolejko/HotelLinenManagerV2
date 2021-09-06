using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServices
{
    public class GetLaundryQuery : QueryBase<LaundryService>
    {
        public int Id { get; set; }
        public override async Task<LaundryService> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.LaundryServices
                .Where(x => x.Id == this.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
