using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Companies
{
    public class GetCompanyQuery : QueryBase<Company>
    {
        public int Id { get; set; }
        public override async Task<Company> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.Companies
                .Include(x => x.CompanyPriceLists)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
