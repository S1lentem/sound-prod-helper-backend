using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoundProdHelper.DAL.Read.Configurations;
using SoundProdHelper.DAL.Read.ContractImplementations;
using SoundProdHelper.Domain.Contracts;

namespace SoundProdHelper.DI.Read
{
    public static class DIBootstrap
    {
        private const string DatabaseType = "Mongo";

        public static IServiceCollection AddAllServices(this IServiceCollection collection, IConfiguration configuration)
        {
            var databaseConfigurations = new DataBaseConfigurations(
                configuration[$"Databases:{DatabaseType}"],
                configuration.GetConnectionString(DatabaseType)
                );

            collection.AddSingleton(databaseConfigurations);

            collection.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyMongoRepository<>));

            return collection;
        }
    }
}