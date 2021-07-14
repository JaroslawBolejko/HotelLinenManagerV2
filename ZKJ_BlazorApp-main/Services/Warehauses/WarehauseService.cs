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
            return await httpService.Get<IEnumerable<Warehause>>("/Warehauses");
        }
    }
}
