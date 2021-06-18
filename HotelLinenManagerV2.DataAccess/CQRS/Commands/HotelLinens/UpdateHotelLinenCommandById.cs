using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinens
{
    public class UpdateHotelLinenByIdCommand : CommandBase<HotelLinen, HotelLinen>
    {
        public override async Task<HotelLinen> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.HotelLinens.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }

    }
}
