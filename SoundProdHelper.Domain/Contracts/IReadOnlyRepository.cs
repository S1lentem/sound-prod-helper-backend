using System.Collections.Generic;
using System.Threading.Tasks;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Specifications;

namespace SoundProdHelper.Domain.Contracts
{
    public interface IReadOnlyRepository<T>
        where T: EntityBase
    {
        Task<T> GetSingleOrDefaultAsync(FilterSpecificationBase<T> filterSpecification);
        Task<IEnumerable<T>> GetAsync(FilterSpecificationBase<T> filterSpecification);
        Task<IEnumerable<T>> GetAsync();
        Task<bool> AnyAsync(FilterSpecificationBase<T> filterSpecification);
    }
}