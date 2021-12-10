using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Invoices
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAllInvoices();
      //  Task<IEnumerable<Invoice>> GetInvoiceByNumber(string number);
        Task<Invoice> GetInvoiceById(int id);
        Task<Invoice> CreateInvoice(Invoice invoice);
        Task<int> UpdateInvoice(Invoice invoice);
        Task<bool> Delete(int id);
    }
}
