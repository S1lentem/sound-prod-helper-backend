using System;
using System.Threading.Tasks;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.DAL.Write.ContractImplementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoundProdHelperContext _context;

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IDisposable> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync()
                .ConfigureAwait(false);
        }

        public Task CommitTransactionAsync()
        {
            _context.Database.CommitTransaction();
            return Task.CompletedTask;
        }

        public Task RollBackTransactionAsync()
        {
            _context.Database.RollbackTransaction();
            return Task.CompletedTask;
        }
    }
}