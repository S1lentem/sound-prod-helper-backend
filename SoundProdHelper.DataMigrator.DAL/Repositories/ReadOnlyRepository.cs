using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoundProdHelper.DAL.Write;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Specifications;

namespace SoundProdHelper.DataMigrator.DAL.Repositories
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> 
        where T : EntityBase
    {
        private readonly IQueryable<T> query;

        public ReadOnlyRepository(SoundProdHelperContext context)
        {
            query = context.Set<T>();
        }

        public async Task<T> GetSingleOrDefaultAsync(FilterSpecificationBase<T> filterSpecification)
        {
            return await query.FirstOrDefaultAsync(filterSpecification.Predicate)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAsync(FilterSpecificationBase<T> filterSpecification)
        {
            return await query.Where(filterSpecification.Predicate)
                .ToArrayAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await query.ToArrayAsync()
                .ConfigureAwait(false);
        }



        public Task<bool> AnyAsync(FilterSpecificationBase<T> filterSpecification)
        {
            throw new System.NotImplementedException();
        }
    }
}