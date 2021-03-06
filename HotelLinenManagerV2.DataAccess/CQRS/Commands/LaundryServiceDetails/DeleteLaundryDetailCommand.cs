using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.LaundryServiceDetails
{
    public class DeleteLaundryDetailCommand : CommandBase<LaundryServiceDetail, bool>
     {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.LaundryServiceDetails.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
