using HotelLinenManagerV2.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly WarehauseStorageHotelLinenContext context;

        public QueryExecutor(WarehauseStorageHotelLinenContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
