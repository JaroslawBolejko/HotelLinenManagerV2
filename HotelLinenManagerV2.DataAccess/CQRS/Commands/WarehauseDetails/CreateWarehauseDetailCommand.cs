using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.WarehauseDetails
{
    public class CreateWarehauseDetailCommand : CommandBase<WarehauseDetail, WarehauseDetail>
    {
        public override async Task<WarehauseDetail> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.WarehauseDetails.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
