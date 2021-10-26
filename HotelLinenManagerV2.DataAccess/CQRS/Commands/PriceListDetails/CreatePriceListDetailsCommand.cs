using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceListDetails
{
    public class CreatePriceListDetailsCommand : CommandBase<PriceListDetail, PriceListDetail>
    {
        public override async Task<PriceListDetail> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.PriceListDetails.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
