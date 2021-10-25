using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceLists
{
    public class CreatePriceListCommand : CommandBase<PriceList, PriceList>
    {
        public override async Task<PriceList> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.PriceLists.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
