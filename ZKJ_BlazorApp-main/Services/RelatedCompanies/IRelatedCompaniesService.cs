using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.RelatedCompanies
{
    public interface IRelatedCompaniesService
    {
        Task<IEnumerable<RelatedCompany>> GetAllRelatedCompanies();
        Task<int> CreateRelatedCompany(RelatedCompany relatedCompany);
        Task<bool> DeleteRelatedCompany(int id);
    }
}
