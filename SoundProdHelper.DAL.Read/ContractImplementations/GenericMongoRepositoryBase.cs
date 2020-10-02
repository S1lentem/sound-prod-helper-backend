using MongoDB.Driver;
using SoundProdHelper.DAL.Read.Configurations;
using SoundProdHelper.Domain.Base;

namespace SoundProdHelper.DAL.Read.ContractImplementations
{
    public abstract class GenericMongoRepositoryBase<T>
        where T: EntityBase
    {
        protected readonly IMongoCollection<T> Collection;

        protected GenericMongoRepositoryBase(DataBaseConfigurations configurations)
        {
            Collection = new MongoClient(configurations.ConnectionString)
                .GetDatabase(configurations.DataBaseName)
                .GetCollection<T>(configurations.CollectionNameMap[typeof(T)]);
        }
    }
}