using System.Threading.Tasks;
using SoundProdHelper.Domain.Base;

namespace SoundProdHelper.Domain.Contracts
{
    public interface IWriteOnlyRepository<T>
        where T : EntityBase
    {
        Task<T> AddAsync(T entity);
    }
}