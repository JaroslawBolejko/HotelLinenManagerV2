using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses
{
    public class CreateWarehauseCommand : CommandBase<Warehause, Warehause>
    {
        public override async Task<Warehause> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.Warehauses.AddAsync(this.Parameter);

            if(this.Parameter.WarehauseDetails.Count !=0)
            {
                await context.WarehauseDetails.AddRangeAsync(this.Parameter.WarehauseDetails);
            }

            await context.SaveChangesAsync();

            return this.Parameter;
        }
    }
}
