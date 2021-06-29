using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelLinenManagerV2.DataAccess
{
    public class WarehauseStorageHotelLinenContextFactory : IDesignTimeDbContextFactory<WarehauseStorageHotelLinenContext>
    {
       // private readonly IConfiguration configuration;
            
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehauseStorageHL;Integrated Security=True";
        // readonly string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
        // .GetSection("ConnectionStrings")["HotelLinenWarhauseConnection"];
        public WarehauseStorageHotelLinenContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<WarehauseStorageHotelLinenContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new WarehauseStorageHotelLinenContext(optionBuilder.Options);
        }

        
    }
}
