using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.LaundryServices
{
    public class CreateLaundryCommand : CommandBase<LaundryService, LaundryService>
    {
        public override async Task<LaundryService> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.LaundryServices.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
