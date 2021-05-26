using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses
{
    public class DeleteWarhauseCommand : CommandBase<Warehause, Warehause>
    {
        public override async Task<Warehause> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.Warehauses.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;


        }
    }
}
