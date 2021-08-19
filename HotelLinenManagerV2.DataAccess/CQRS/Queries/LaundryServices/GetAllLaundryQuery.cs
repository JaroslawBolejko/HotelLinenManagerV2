using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServices
{
    public class GetAllLaundryQuery : QueryBase<List<LaundryService>>
    {
        public int? LaundryServiceId { get; set; }
        public int? CompanyId { get; set; }
        public override async Task<List<LaundryService>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.LaundryServiceId != null)
            {
                return await context.LaundryServices
                .Where(x=>x.Id == this.LaundryServiceId)
                .Include(x => x.LaundryServiceDetails)
                .ToListAsync();
            }
            if (this.CompanyId != null)
            {
                return await context.LaundryServices
                    .Where(x => x.CompanyId == this.CompanyId).ToListAsync();
            }
            else return null;
            
        }
    }
}
