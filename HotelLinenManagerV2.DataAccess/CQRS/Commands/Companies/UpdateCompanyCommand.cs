using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Companies
{
    public class UpdateCompanyCommand : CommandBase<Company, Company>
    {
        public override async Task<Company> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.Companies.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
