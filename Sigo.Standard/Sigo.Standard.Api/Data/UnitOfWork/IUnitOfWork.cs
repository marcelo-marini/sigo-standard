using System.Threading.Tasks;
using Sigo.Standard.Api.Data.Repositories;

namespace Sigo.Standard.Api.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStandardRepository StandardRepository { get; }
        Task CommitAsync();
    }
}