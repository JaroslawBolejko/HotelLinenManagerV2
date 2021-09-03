using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Users
{
    public class UpdateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
