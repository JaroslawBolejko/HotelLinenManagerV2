using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServices
{
    public class GetAllLaundryQuery : QueryBase<List<LaundryService>>
    {
        public int? Number { get; set; }
        public int? CompanyId { get; set; }
        //public int PageSize { get; set; }
        //public int PageNumber { get; set; }
        public override async Task<List<LaundryService>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.Number != null && this.CompanyId!=null)
            {
                return await context.LaundryServices
                    .Where(x => x.Number == this.Number).ToListAsync();
            }
            else if (this.CompanyId != null)
            {
                return await context.LaundryServices
                    .Where(x => x.CompanyId == this.CompanyId)
                    //.OrderByDescending(x=>x.RecievedDate)
                    //.Skip((PageNumber -1)*PageSize)
                    //.Take(PageSize)
                    .ToListAsync();
            }
            else return null;

        }
    }
}
