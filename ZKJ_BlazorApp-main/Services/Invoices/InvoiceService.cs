using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IHttpService httpService;

        public InvoiceService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<int> CreateInvoice(Invoice invoice)
        {
            var result = await this.httpService.Post<Invoice>($"/invoices", invoice);
            return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            await this.httpService.Delete($"/invoices/{id}");
            return true;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
          var result = await this.httpService.Get<IEnumerable<Invoice>>("/invoices");
            return result;
        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            var result = await this.httpService.Get<Invoice>($"/invoices/{id}");
            return result;
        }

        //public Task<IEnumerable<Invoice>> GetInvoiceByNumber(string number)
        //{
        //    throw new System.NotImplementedException();
        //}

        public async  Task<int> UpdateInvoice(Invoice invoice)
        {
            var result = await this.httpService.Put<Invoice>($"/invoices/{invoice.Id}",invoice);
            return result.Id;
        }
    }
}
