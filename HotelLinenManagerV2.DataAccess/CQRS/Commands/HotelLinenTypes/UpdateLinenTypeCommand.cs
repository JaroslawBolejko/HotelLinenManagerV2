using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinenTypes
{
    public class UpdateLinenTypeCommand : CommandBase<HotelLinenType, HotelLinenType>
    {
        public override async Task<HotelLinenType> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.HotelLinenTypes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
