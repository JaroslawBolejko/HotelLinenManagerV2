using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceListDetails
{
    public class DeletePriceListDetailsCommand : CommandBase<PriceListDetail, bool>
    {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.PriceListDetails.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
