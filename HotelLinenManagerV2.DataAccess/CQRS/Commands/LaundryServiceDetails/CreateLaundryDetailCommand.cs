using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.LaundryServiceDetails
{
    public class CreateLaundryDetailCommand : CommandBase<LaundryServiceDetail, LaundryServiceDetail>
    {
        public override async Task<LaundryServiceDetail> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.LaundryServiceDetails.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
