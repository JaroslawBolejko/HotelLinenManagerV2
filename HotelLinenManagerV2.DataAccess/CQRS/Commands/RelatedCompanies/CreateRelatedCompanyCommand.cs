using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.RelatedCompanies
{
    public class CreateRelatedCompanyCommand : CommandBase<RelatedCompany, RelatedCompany>
    {
        public override async Task<RelatedCompany> Execute(WarehauseStorageHotelLinenContext context)
        {
            await context.RelatedCompanies.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
