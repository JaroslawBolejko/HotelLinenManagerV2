using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.RelatedCompanies
{
    public class GetAllRelatedCompaniesQuery : QueryBase<List<RelatedCompany>>
    {
        public int? CompanyId { get; set; }
        public int? LaundryId { get; set; }
        public override async Task<List<RelatedCompany>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.CompanyId != null && this.LaundryId != null)
            {
                var result  = await context.RelatedCompanies
                               .Where(x => x.CompanyId == this.CompanyId && x.LaundryId == this.LaundryId)
                               .Include(x => x.Company)
                               .Include(y => y.Laundry)
                               .AsNoTracking()
                               .ToListAsync();
                if (result.Count == 0) return null;
                return result;
            }
            else if(this.CompanyId != null && this.LaundryId == null)
            {
                return await context.RelatedCompanies
                               .Where(x => x.CompanyId == this.CompanyId)
                               .Include(x => x.Company)
                               .Include(y => y.Laundry)
                               .AsNoTracking()
                               .ToListAsync();
            }
            else if (this.CompanyId == null && this.LaundryId != null)
            {
                return await context.RelatedCompanies
                               .Where(x => x.LaundryId == this.LaundryId)
                               .Include(x => x.Company)
                               .Include(y => y.Laundry)
                               .AsNoTracking()
                               .ToListAsync();
            }
            return null;
        }
    }
}
