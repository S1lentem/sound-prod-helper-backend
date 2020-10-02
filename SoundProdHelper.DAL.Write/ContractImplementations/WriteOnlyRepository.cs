using System;
using System.Threading.Tasks;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.DAL.Write.ContractImplementations
{
    public class WriteOnlyRepository<T> : IWriteOnlyRepository<T>
        where T: EntityBase
    {
        private readonly SoundProdHelperContext _context;

        public WriteOnlyRepository(SoundProdHelperContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> AddAsync(T entity)
        {
            var entry = await _context.AddAsync(entity).ConfigureAwait(false);
            return entry.Entity;
        }
    }
}
