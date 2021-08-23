using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.LaundryServices
{
    public class DeleteLaundryCommand : CommandBase<LaundryService, bool>
     {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.LaundryServices.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
