using System;
using System.Threading.Tasks;

namespace SoundProdHelper.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task<IDisposable> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
    }
}