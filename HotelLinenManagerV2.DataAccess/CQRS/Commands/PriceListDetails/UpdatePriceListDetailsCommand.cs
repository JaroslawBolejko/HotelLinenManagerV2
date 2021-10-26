using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceListDetails
{
    public class UpdatePriceListDetailsCommand : CommandBase<PriceListDetail, PriceListDetail>
    {
        public override async Task<PriceListDetail> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.PriceListDetails.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
