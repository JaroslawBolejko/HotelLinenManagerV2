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

        public async Task<int> Create(Company company)
        {
            var result = await this.httpService.Post<Company>("/companies", company);
            return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            await this.httpService.Delete($"/companies/{id}");
            return true;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await this.httpService.Get<IEnumerable<Company>>("/Companies");
        }

        public async  Task<IEnumerable<Company>> GetAll(int companyId)
        {
            return await this.httpService.Get<IEnumerable<Company>>($"/Companies?CompanyId={companyId}");
        }

        public async Task<IEnumerable<Company>> GetAll(string taxNumber)
        {
            return await this.httpService.Get<IEnumerable<Company>>($"/Companies?TaxNumber={taxNumber}");
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await this.httpService.Get<Company>($"/Companies/{id}");
        }

        public async Task<int> Update(Company company)
        {
            var result = await this.httpService.Put<Company>($"/companies/{company.Id}", company);
            return result.Id;
        }
    }
}
