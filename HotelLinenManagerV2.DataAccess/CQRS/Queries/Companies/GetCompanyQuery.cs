using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Companies
{
    public class GetCompanyQuery : QueryBase<Company>
    {
        public int Id { get; set; }
        public override async Task<Company> Execute(WarehauseStorageHotelLinenContext context)
        {
          return  await context.Companies.FirstOrDefaultAsync(x=>x.Id == this.Id);
            
        }
    }
}
