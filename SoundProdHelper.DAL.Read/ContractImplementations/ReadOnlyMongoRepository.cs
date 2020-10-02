using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SoundProdHelper.DAL.Read.Configurations;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Domain.Specifications;

namespace SoundProdHelper.DAL.Read.ContractImplementations
{
    public class ReadOnlyMongoRepository<T> : GenericMongoRepositoryBase<T>, IReadOnlyRepository<T>
        where T: EntityBase
    {
        public ReadOnlyMongoRepository(DataBaseConfigurations configurations) : base(configurations)
        {
        }


        public async Task<T> GetSingleOrDefaultAsync(FilterSpecificationBase<T> filterSpecification)
        {
            return await Collection.Find(filterSpecification.Predicate)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAsync(FilterSpecificationBase<T> filterSpecification)
        {
            return  await Collection.Find(filterSpecification.Predicate)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Collection.Find(Builders<T>.Filter.Empty)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> AnyAsync(FilterSpecificationBase<T> filterSpecification)
        {
            return await Collection.Find(filterSpecification.Predicate)
                .AnyAsync()
                .ConfigureAwait(false);
        }
    }
}