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
        public string UserRole { get; set; }

        public override async Task<List<LaundryService>> Execute(WarehauseStorageHotelLinenContext context)
        {
            if (!string.IsNullOrEmpty(this.Number))
            {
                return await context.LaundryServices
                    .Where(x => x.Number == this.Number)
                    .Include(x => x.Company)
                    .Include(x => x.Laundry)
                    .AsNoTracking()
                    .ToListAsync();
            }

            if (UserRole == "UserLaundry")
            {
                return await context.LaundryServices
                    .Where(x => x.LaundryId == this.CompanyId)
                    .OrderByDescending(x => x.RecievedDate)
                    .ThenByDescending(x => x.Id)
                    .Include(x => x.Company)
                    .Include(x => x.Laundry)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if (UserRole == "UserHotel" || UserRole == "AdminHotel")
            {
                return await context.LaundryServices
                    .Where(x => x.CompanyId == this.CompanyId)
                    .OrderByDescending(x => x.RecievedDate)
                    .ThenByDescending(x => x.Id)
                    .Include(x => x.Company)
                    .Include(x => x.Laundry)
                    .AsNoTracking()
                    .ToListAsync();
            }

            else return null;

        }
    }
}
