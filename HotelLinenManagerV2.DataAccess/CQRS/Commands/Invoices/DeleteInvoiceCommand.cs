using HotelLinenManagerV2.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands.Invoices
{
    public class DeleteInvoiceCommand : CommandBase<Invoice, bool>
    {
        public override async Task<bool> Execute(WarehauseStorageHotelLinenContext context)
        {
            context.ChangeTracker.Clear();
            context.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
