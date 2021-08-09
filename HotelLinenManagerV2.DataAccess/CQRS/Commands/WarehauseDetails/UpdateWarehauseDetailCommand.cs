using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.WarehauseDetails
{
    public class UpdateWarehauseDetailCommand : CommandBase<WarehauseDetail, WarehauseDetail>
    {
        public override async Task<WarehauseDetail> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.WarehauseDetails.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
