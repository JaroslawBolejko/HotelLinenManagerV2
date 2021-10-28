using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Companies
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetCompanyById(int id);
        Task<int> Create(Company company);
        Task<bool> Delete(int id);
        Task<int> Update(Company company);
    }
}

