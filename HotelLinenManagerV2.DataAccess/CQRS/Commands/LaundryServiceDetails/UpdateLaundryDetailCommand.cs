using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.LaundryServiceDetails
{
    public class UpdateLaundryDetailCommand : CommandBase<LaundryServiceDetail, LaundryServiceDetail>
    {
        public override async Task<LaundryServiceDetail> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.LaundryServiceDetails.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
