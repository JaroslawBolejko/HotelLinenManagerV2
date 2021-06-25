using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelLinenManagerV2.DataAccess
{
    public class WarehauseStorageHotelLinenContextFactory : IDesignTimeDbContextFactory<WarehauseStorageHotelLinenContext>
    {
        private readonly IConfiguration configuration;

        
        public WarehauseStorageHotelLinenContextFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehauseStorageHL;Integrated Security=True";
        //  readonly string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["HotelLinenWarhauseConnection"];
        public WarehauseStorageHotelLinenContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<WarehauseStorageHotelLinenContext>();
            optionBuilder.UseSqlServer(configuration.GetConnectionString("HotelLinenWarhauseConnection"));
            return new WarehauseStorageHotelLinenContext(optionBuilder.Options);
        }

        
    }
}
