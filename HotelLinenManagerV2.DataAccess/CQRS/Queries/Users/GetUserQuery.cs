using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Users
{
    public class GetUserQuery : QueryBase<User>
    {
        public string Username { get; set; }
        public override async Task<User> Execute(WarehauseStorageHotelLinenContext context)
        {
            var result = await context.Users.FirstOrDefaultAsync(x => x.Username == this.Username);
            return result;

        }
    }
}
