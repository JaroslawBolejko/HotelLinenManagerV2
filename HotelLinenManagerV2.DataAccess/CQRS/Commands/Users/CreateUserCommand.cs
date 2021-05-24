using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Users
{
    public class CreateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();

            return this.Parameter;
        }
    }
}
