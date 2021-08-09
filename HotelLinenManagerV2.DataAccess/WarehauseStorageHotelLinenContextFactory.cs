using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelLinenManagerV2.DataAccess
{
    public class WarehauseStorageHotelLinenContextFactory : IDesignTimeDbContextFactory<WarehauseStorageHotelLinenContext>
    {
                  
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehauseStorageHL;Integrated Security=True";
       
        public WarehauseStorageHotelLinenContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<WarehauseStorageHotelLinenContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new WarehauseStorageHotelLinenContext(optionBuilder.Options);
        }

        
    }
}
