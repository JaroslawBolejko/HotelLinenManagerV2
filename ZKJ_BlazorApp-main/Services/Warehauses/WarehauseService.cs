using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Warehauses
{
    public class WarehauseService : IWarehauseService
    {
        private readonly IHttpService httpService;

        public WarehauseService(IHttpService httpService) 
        {
            this.httpService = httpService;
        }

        public async Task<int> CreateWarehause(Warehause warehause)
        {
            var result =  await this.httpService.Post<Warehause>("/Warehauses", warehause);
            return result.Id;

        }

        public async Task<IEnumerable<Warehause>> GetAll()
        {
            return await this.httpService.Get<IEnumerable<Warehause>>("/Warehauses");
        }

        public async Task<Warehause> GetWarehauseById(int id)
        {
            return await this.httpService.Get<Warehause>($"/Warehauses/{id}");

        }
        public async Task<int> Update(int id, Warehause warehause)
        {
            var result = await this.httpService.Put<Warehause>($"/Warehauses/{id}", warehause);
            return id;
        }
    }
}
