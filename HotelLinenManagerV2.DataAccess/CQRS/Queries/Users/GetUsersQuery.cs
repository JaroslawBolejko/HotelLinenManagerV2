using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Users
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public override async Task<List<User>> Execute(WarehauseStorageHotelLinenContext context)
        {
            var result = await context.Users.ToListAsync();

            return result;
        }
    }
}
