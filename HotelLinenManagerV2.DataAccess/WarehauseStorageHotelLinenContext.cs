using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelLinenManagerV2.DataAccess
{
    public class WarehauseStorageHotelLinenContext : DbContext
    {
        public WarehauseStorageHotelLinenContext (DbContextOptions<WarehauseStorageHotelLinenContext> opt) : base(opt)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<HotelLinen> HotelLinens { get; set; }
        public DbSet<HotelLinenType> HotelLinenTypes { get; set; }
        public DbSet<Warehause> Warehauses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<HLBaseQuantity> HLBaseQuantities { get; set; }
        public DbSet<LaundryService> LaundryServices { get; set; }
        public DbSet<WarehauseDetail> WarehauseDetails { get; set; }



    }
}
