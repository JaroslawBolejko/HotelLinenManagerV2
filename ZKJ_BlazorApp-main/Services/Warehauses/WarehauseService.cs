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

        public async Task<IEnumerable<Warehause>> GetAll()
        {
            return await this.httpService.Get<IEnumerable<Warehause>>("/Warehauses");
        }

        public async Task<Warehause> GetWarehauseById(int id)
        {
            return await this.httpService.Get<Warehause>($"/Warehauses/{id}");

        }
        public async Task<int> Update(Warehause warehause)
        {
            var result = await this.httpService.Put<Warehause>($"/Warehauses/{warehause.Id}", warehause);
            return result.Id;
        }
    }
}
