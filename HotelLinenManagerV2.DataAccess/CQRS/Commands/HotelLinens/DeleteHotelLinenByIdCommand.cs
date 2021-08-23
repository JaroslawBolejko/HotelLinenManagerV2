using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinens
{
    public class DeleteHotelLinenByIdCommand : CommandBase<HotelLinen, bool>
    {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.HotelLinens.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
