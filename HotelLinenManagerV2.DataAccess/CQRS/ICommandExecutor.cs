using HotelLinenManagerV2.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command);
    }
}
