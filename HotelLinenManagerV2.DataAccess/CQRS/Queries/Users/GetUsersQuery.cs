using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Users
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public int CompanyId { get; set; }
        public override async Task<List<User>> Execute(WarehauseStorageHotelLinenContext context)
        {
            var result = await context.Users
                .Where(x=>x.CompanyId==this.CompanyId)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }
    }
}
