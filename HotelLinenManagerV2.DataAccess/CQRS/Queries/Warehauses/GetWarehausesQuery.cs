using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Warehauses
{
    public class GetWarehausesQuery : QueryBase<List<Warehause>>
    {
        public int? WarehauseNumber { get; set; }
        public int? CompanyId { get; set; }
        public byte? WarehauseType { get; set; }
        public override async Task<List<Warehause>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.WarehauseNumber != null && this.CompanyId != null && this.WarehauseType == null)
            {
                if (context.Warehauses.Any(x => x.WarehauseNumber == this.WarehauseNumber && x.CompanyId == this.CompanyId))
                {

                    return await context.Warehauses.Where(x => x.WarehauseNumber == this.WarehauseNumber && x.CompanyId == this.CompanyId)
                        .Include(x => x.WarehauseDetails)
                        .AsNoTracking()
                        .ToListAsync();
                }
                return null;
            }

            if (this.WarehauseNumber != null && this.CompanyId == null && this.WarehauseType == null)
            {
                if (context.Warehauses.Any(x => x.WarehauseNumber == this.WarehauseNumber))
                {

                    return await context.Warehauses.Where(x => x.WarehauseNumber == this.WarehauseNumber)
                        .Include(x => x.WarehauseDetails)
                        .AsNoTracking()
                        .ToListAsync();
                }
                return null;
            }

            if (this.WarehauseNumber == null && this.CompanyId != null && this.WarehauseType == null)
            {
                if (context.Warehauses.Any(x => x.CompanyId == this.CompanyId))
                {

                    return await context.Warehauses.Where(x => x.CompanyId == this.CompanyId)
                        .Include(x => x.WarehauseDetails)
                        .AsNoTracking()
                        .ToListAsync();
                }
                return null;
            }
            var result = await context.Warehauses
                .Include(x => x.WarehauseDetails)
                .AsNoTracking()
                .ToListAsync();

            if (this.WarehauseType != null && this.CompanyId != null && this.WarehauseNumber == null)
            {
                return await context.Warehauses
                    .Where(x => (byte)x.WarehauseType == this.WarehauseType && x.CompanyId == this.CompanyId)
                    .Include(x=>x.WarehauseDetails)
                    .AsNoTracking()
                    .ToListAsync();
            }

            return result;
        }
    }
}
