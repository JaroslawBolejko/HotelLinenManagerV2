using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinenTypes
{
    public class GetLinenTypeQuery : QueryBase<HotelLinenType>
    {
        public int Id { get; set; }
        
        public override async Task<HotelLinenType> Execute(WarehauseStorageHotelLinenContext context)
        {

            return await context.HotelLinenTypes
                .Where(x => x.Id == this.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        }
    }
}
