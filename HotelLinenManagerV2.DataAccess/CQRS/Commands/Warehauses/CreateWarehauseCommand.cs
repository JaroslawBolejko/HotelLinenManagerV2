using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses
{
    public class CreateWarehauseCommand : CommandBase<Warehause, Warehause>
    {
        public override async Task<Warehause> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.Warehauses.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
