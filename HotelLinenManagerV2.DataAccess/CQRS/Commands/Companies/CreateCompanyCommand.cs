using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Companies
{
    public class CreateCompanyCommand : CommandBase<Company, Company>
    {
        public override async Task<Company> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.Companies.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
