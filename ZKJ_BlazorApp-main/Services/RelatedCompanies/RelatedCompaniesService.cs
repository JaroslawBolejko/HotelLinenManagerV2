using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.RelatedCompanies
{
    public class RelatedCompaniesService : IRelatedCompaniesService
    {
        private readonly IHttpService httpService;

        public RelatedCompaniesService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<int> CreateRelatedCompany(RelatedCompany relatedCompany)
        {
            var result = await this.httpService.Post<RelatedCompany>("/relatedCompanies", relatedCompany);
            return result.Id;
        }

        public async Task<bool> DeleteRelatedCompany(int id)
        {
            await this.httpService.Delete($"/relatedCompanies/{id}");
            return true;
        }

        public async Task<IEnumerable<RelatedCompany>> GetAllRelatedCompanies()
        {
            return await this.httpService.Get<IEnumerable<RelatedCompany>>("/relatedCompanies");
        }

        public async  Task<IEnumerable<RelatedCompany>> GetAllRelatedCompanies(int companyId)
        {
            return await this.httpService.Get<IEnumerable<RelatedCompany>>($"/relatedCompanies?companyId={companyId}");

        }
    }
}
