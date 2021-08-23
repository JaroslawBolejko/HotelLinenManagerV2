using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses
{
    public class DeleteWarhauseCommand : CommandBase<Warehause, bool>
    {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.Warehauses.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;

        }
    }
}
