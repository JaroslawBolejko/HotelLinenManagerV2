using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServiceDetails
{
    public class GetAllLaundryDetailsQuery : QueryBase<List<LaundryServiceDetail>>
    {

        public override async Task<List<LaundryServiceDetail>> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.LaundryServiceDetails.ToListAsync();
        }
    }
}
