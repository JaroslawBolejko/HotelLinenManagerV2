using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Companies
{
    public class GetCompaniesQuery : QueryBase<List<Company>>
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public int? CompanyId { get; set; }
        public override async Task<List<Company>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if(!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(TaxNumber))
            {
                var result = await context.Companies
                    .Where(x => x.Name == this.Name && x.TaxNumber == this.TaxNumber)
                    .Include(x=>x.CompanyPriceLists)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            else if (!string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(TaxNumber))
            {
                var result = await context.Companies
                    .Where(x => x.Name == this.Name )
                    .Include(x => x.CompanyPriceLists)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
           else if (string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(TaxNumber))
            {
                var result = await context.Companies
                    .Where(x =>x.TaxNumber == this.TaxNumber)
                    .Include(x => x.CompanyPriceLists)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            else if (this.CompanyId != null && string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(TaxNumber))
            {
                return await context.Companies
                    .Where(x => x.Id == this.CompanyId)
                    .Include(x => x.CompanyPriceLists)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else  return await context.Companies
                .Include(x => x.CompanyPriceLists)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
