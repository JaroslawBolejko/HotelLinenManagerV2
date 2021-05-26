using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinens
{
    public class CreateHoteLinenCommand : CommandBase<HotelLinen, HotelLinen>
    {
        public override async Task<HotelLinen> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.HotelLinens.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
