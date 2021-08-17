using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServiceDetails
{
    public class GetLaundryDetailsQuery : QueryBase<LaundryServiceDetail>
    {
        public int Id { get; set; }
        public override async Task<LaundryServiceDetail> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.LaundryServiceDetails.Where(x => x.Id == this.Id).FirstOrDefaultAsync();
        }
    }
}
