using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinenTypes
{
    public class DeleteLinenTypeCommand : CommandBase<HotelLinenType, bool>
    {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.HotelLinenTypes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
