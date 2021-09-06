using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServices
{
    public class GetAllLaundryQuery : QueryBase<List<LaundryService>>
    {
        public string Number { get; set; }
        public int? CompanyId { get; set; }
        //public int Skip { get; set; }
        //public int Take { get; set; }
        public override async Task<List<LaundryService>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (!string.IsNullOrEmpty(this.Number) && this.CompanyId!=null)
            {
                return await context.LaundryServices
                    .Where(x => x.Number == this.Number)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if (this.CompanyId != null)
            {
                return await context.LaundryServices
                    .Where(x => x.CompanyId == this.CompanyId)
                    //.Skip(this.Skip)
                    //.Take(this.Take)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else return null;

        }
    }
}
