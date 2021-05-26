using HotelLinenManagerV2.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses
{
    public class UpdateWarehauseCommand : CommandBase<Warehause, Warehause>
    {
        public override async Task<Warehause> Execute(WarehauseStorageHotelLinenContext context)
        {
            //context.ChangeTracker.Clear();
            context.Warehauses.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
