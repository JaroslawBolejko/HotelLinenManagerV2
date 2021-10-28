using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.RelatedCompanies
{
    public class DeleteRelatedCompanyCommand : CommandBase<RelatedCompany, bool>
    {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.RelatedCompanies.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
