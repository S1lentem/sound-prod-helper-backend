using System.Threading.Tasks;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.UserService.DAL.Repositories
{
    public class WriteOnlyRepository<T> : IWriteOnlyRepository<T>
        where T: EntityBase
    {
        public Task<T> AddAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}