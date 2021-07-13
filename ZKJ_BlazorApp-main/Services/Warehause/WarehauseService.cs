using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
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
    }
}
