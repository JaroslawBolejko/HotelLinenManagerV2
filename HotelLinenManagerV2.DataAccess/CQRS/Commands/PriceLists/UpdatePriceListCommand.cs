using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceLists
{
    public class UpdatePriceListCommand : CommandBase<PriceList, PriceList>
    {
        public override async Task<PriceList> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.PriceLists.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
