using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IHttpService httpService;

        public CompanyService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await this.httpService.Get<IEnumerable<Company>>("/Companies");
        }
        public async Task<Company> GetCompanyById(int id)
        {
            return await this.httpService.Get<Company>($"/Companies/{id}");
        }
    }
}
