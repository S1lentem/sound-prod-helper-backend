using System;
using System.Threading.Tasks;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.UserService.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDisposable> BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task RollBackTransactionAsync()
        {
            throw new NotImplementedException();
        }
    }
}