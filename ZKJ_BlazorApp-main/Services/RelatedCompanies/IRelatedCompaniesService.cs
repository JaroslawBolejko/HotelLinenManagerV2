using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.RelatedCompanies
{
    public interface IRelatedCompaniesService
    {
        Task<IEnumerable<RelatedCompany>> GetAllRelatedCompanies();
        Task<IEnumerable<RelatedCompany>> GetAllRelatedCompanies(int copmanyId);
        Task<int> CreateRelatedCompany(RelatedCompany relatedCompany);
        Task<bool> DeleteRelatedCompany(int id);
    }
}
