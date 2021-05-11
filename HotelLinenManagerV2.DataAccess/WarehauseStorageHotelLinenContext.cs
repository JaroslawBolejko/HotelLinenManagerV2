using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess
{
    public class WarehauseStorageHotelLinenContext : DbContext
    {
        public WarehauseStorageHotelLinenContext (DbContextOptions<WarehauseStorageHotelLinenContext> opt) : base(opt)
        {
        }
        public DbSet<HotelLinen> HotelLinens { get; set; }
        public DbSet<Warehause> Warehauses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }



    }
}
