using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceLists
{
    public class DeletePriceListCommand : CommandBase<PriceList, bool>
    {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.PriceLists.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;

        }
    }
}
