using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Companies
{
    public class DeleteCompanyCommand : CommandBase<Company, Company>
    {
        public override async Task<Company> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.Companies.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
