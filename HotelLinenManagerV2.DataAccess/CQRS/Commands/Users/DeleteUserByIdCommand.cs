using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Users
{
    public class DeleteUserByIdCommand : CommandBase<User, bool>
    {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
