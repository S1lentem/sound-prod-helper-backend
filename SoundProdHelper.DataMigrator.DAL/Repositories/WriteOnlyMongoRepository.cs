using System.Threading.Tasks;
using MongoDB.Driver;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.DataMigrator.DAL.Repositories
{
    public class WriteOnlyMongoRepository<T> : IWriteOnlyRepository<T>
        where T : EntityBase
    {

        private readonly IMongoCollection<T> _collection;
        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity).ConfigureAwait(false);
            return entity;
        }
    }
}