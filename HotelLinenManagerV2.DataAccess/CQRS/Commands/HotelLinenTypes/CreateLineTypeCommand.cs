using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.HotelLinenTypes
{
    public class CreateLineTypeCommand : CommandBase<HotelLinenType, HotelLinenType>
    {
        public override async  Task<HotelLinenType> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.HotelLinenTypes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
