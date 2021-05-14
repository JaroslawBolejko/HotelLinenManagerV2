using HotelLinenManagerV2.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
