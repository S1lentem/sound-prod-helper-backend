using Microsoft.Extensions.DependencyInjection;
using SoundProdHelper.Crypto;
using SoundProdHelper.Crypto.Interfaces;
using SoundProdHelper.Crypto.RSA;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.UserService.DAL;
using SoundProdHelper.UserService.DAL.Repositories;

namespace SoundProdHelper.UserService.DI
{
    public static class DIBootstrap
    {
        public static void AddServices(this IServiceCollection collection)
        {
            collection.AddScoped<IUnitOfWork, UnitOfWork>();

            collection.AddScoped<IRSACryptoEngine, RsaEngine>();
            collection.AddSingleton<IEnDeCoder, RsaEnDeCoder>();
            collection.AddSingleton<IHashManager, HashManager>();

            collection.AddScoped(typeof(IWriteOnlyRepository<>), typeof(WriteOnlyRepository<>));
            collection.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
        }
    }
}