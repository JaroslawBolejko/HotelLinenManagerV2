using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Invoices
{
    public class UpdateInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.Update(this.Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
