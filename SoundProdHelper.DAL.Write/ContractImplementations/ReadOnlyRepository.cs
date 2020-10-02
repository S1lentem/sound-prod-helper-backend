using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Specifications;

namespace SoundProdHelper.DAL.Write.ContractImplementations
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> 
        where T : EntityBase
    {
        private readonly IQueryable<T> _query;

        public ReadOnlyRepository(SoundProdHelperContext context)
        {
            _query = context.Set<T>();
        }

        public async Task<T> GetSingleOrDefaultAsync(FilterSpecificationBase<T> filterSpecification)
        {
            return await _query.FirstOrDefaultAsync(filterSpecification.Predicate)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAsync(FilterSpecificationBase<T> filterSpecification)
        {
            return await _query.Where(filterSpecification.Predicate)
                .ToArrayAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _query.ToArrayAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> AnyAsync(FilterSpecificationBase<T> filterSpecification)
        {
            return await _query.AnyAsync(filterSpecification.Predicate)
                .ConfigureAwait(false);
        }
    }
}