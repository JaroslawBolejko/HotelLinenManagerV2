using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelLinenManagerV2.DataAccess
{
    public class WarehauseStorageHotelLinenContextFactory : IDesignTimeDbContextFactory<WarehauseStorageHotelLinenContext>
    {
                  
        string connectionStringLocal = "Data Source=.\\SQLEXPRESS;Initial Catalog=WarehauseStorageHL;Integrated Security=True";
        string connectionStringAzure = "Server=tcp:hotellinenwarehause.database.windows.net,1433;Initial Catalog=HotelLinenWarehauseStorage;Persist Security Info=False;User ID=jarokm;Password=Kravmaga85;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
       
        public WarehauseStorageHotelLinenContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<WarehauseStorageHotelLinenContext>();
            optionBuilder.UseSqlServer(connectionStringLocal);
            return new WarehauseStorageHotelLinenContext(optionBuilder.Options);
        }

        
    }
}
