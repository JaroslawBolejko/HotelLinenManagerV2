using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.WarehauseDetails
{
    public class DeleteWarehauseDetailCommand : CommandBase<WarehauseDetail, bool>
     {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.WarehauseDetails.Remove(this.Parameter);
            await context.SaveChangesAsync();
            // return this.Parameter;
            return true;
        }
    }
}
