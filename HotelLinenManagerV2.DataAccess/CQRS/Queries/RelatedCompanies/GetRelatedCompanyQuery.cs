using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.RelatedCompanies
{
    public class GetRelatedCompanyQuery : QueryBase<RelatedCompany>
    {
        public int Id { get; set; }
        public override async Task<RelatedCompany> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.RelatedCompanies
                .Where(x => x.Id == this.Id)
                .Include(x => x.Company)
                .Include(y => y.Laundry)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
