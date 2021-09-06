using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServiceDetails
{
    public class GetAllLaundryDetailsQuery : QueryBase<List<LaundryServiceDetail>>
    {
        public int? LaundryServiceId { get; set; }
        public int? CompanyId { get; set; }
      
        public override async Task<List<LaundryServiceDetail>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (this.LaundryServiceId != null && this.CompanyId!=null)
            {
                return await context.LaundryServiceDetails
                    .Where(x => x.LaundryServiceId == this.LaundryServiceId)
                    .Include(x=>x.HotelLinen)
                    .AsNoTracking()
                    .ToListAsync();

            }
            else if (this.CompanyId != null && this.LaundryServiceId==null)
            {
                var result = await context.LaundryServiceDetails
                    .Join(context.LaundryServices, laundryDetails => laundryDetails.LaundryServiceId, laundryService => laundryService.Id
                    , (laundryDetails, laundryService) => new
                    {
                        LaundrServiceDetailId = laundryDetails.Id,
                        LaundryServiceId = laundryService.Id,
                        CompanyId = laundryService.CompanyId
                    })
                    .AsNoTracking()
                    .ToListAsync();

                List<LaundryServiceDetail> returnList = new();
                var result2 = result.Where(x => x.CompanyId == this.CompanyId).Select(x => x.LaundrServiceDetailId).Distinct().ToList();
                for (int i = 0; i < result2.Count; i++)
                {
                    var item = await context.LaundryServiceDetails
                        .Where(x => x.Id == result2[i])
                        .AsNoTracking()
                        .ToListAsync();

                    if (item != null) returnList.AddRange(item);
                }
                return returnList;
            }
            
            else return null;
        }
    }
}
