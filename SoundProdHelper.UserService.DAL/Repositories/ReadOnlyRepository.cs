using System.Collections.Generic;
using System.Threading.Tasks;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Specifications;

namespace SoundProdHelper.UserService.DAL.Repositories
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T>
        where T: EntityBase
    {
        public Task<T> GetSingleOrDefaultAsync(FilterSpecificationBase<T> filterSpecification)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAsync(FilterSpecificationBase<T> filterSpecification)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AnyAsync(FilterSpecificationBase<T> filterSpecification)
        {
            throw new System.NotImplementedException();
        }
    }
}