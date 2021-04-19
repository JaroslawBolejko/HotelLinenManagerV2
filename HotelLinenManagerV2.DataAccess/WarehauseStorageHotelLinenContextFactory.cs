using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess
{
    public class WarehauseStorageHotelLinenContextFactory : IDesignTimeDbContextFactory<WarehauseStorageHotelLinenContext>
    {
        public WarehauseStorageHotelLinenContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<WarehauseStorageHotelLinenContext>();
            optionBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=WarehauseStorageHL;Integrated Security=True");
            return new WarehauseStorageHotelLinenContext(optionBuilder.Options);
        }
    }
}
