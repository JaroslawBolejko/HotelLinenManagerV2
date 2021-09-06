using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    .Where(x => x.Name == this.Name && x.TaxNumber == this.TaxNumber && x.Id==this.CompanyId)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            if (!string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(TaxNumber))
            {
                var result = await context.Companies
                    .Where(x => x.Name == this.Name && x.Id == this.CompanyId)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            if (string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(TaxNumber))
            {
                var result = await context.Companies
                    .Where(x =>x.TaxNumber == this.TaxNumber && x.Id == this.CompanyId)
                    .AsNoTracking()
                    .ToListAsync();
                if (result.Count == 0)
                    return null;
                return result;
            }
            if (this.CompanyId!= null)
            {
                return await context.Companies
                    .Where(x => x.Id == this.CompanyId)
                    .AsNoTracking()
                    .ToListAsync();
            }
            return await context.Companies
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
