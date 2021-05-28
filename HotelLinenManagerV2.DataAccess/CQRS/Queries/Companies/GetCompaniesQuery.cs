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
        public override async Task<List<Company>> Execute(WarehauseStorageHotelLinenContext context)
        {
            return await context.Companies.ToListAsync();
        }
    }
}
