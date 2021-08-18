using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServices
{
    public class GetAllLaundryQuery : QueryBase<List<LaundryService>>
    {

        public override async Task<List<LaundryService>> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.LaundryServices
                .Include(x=>x.LaundryServiceDetails)
                .ToListAsync();
        }
    }
}
