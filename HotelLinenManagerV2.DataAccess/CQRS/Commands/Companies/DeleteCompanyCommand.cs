using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Companies
{
    public class DeleteCompanyCommand : CommandBase<Company, bool>
    {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.Companies.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
