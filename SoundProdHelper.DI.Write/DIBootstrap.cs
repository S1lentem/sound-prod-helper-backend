using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoundProdHelper.Common;
using SoundProdHelper.DAL.Write;
using SoundProdHelper.DAL.Write.ContractImplementations;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.Infrastructure.RabbitMQ;

namespace SoundProdHelper.DI.Write
{
    public static class DIBootstrap
    {
        private const string DbConnectionKey = "pg";

        public static IServiceCollection AddAllServices(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddDbContext<SoundProdHelperContext>(opt => opt.UseNpgsql(configuration.GetConnectionString(DbConnectionKey)));

            collection.AddScoped<IUnitOfWork, UnitOfWork>();
            collection.AddScoped(typeof(IWriteOnlyRepository<>), typeof(WriteOnlyRepository<>));

            collection.AddMediatR(typeof(CommandHandlerBase<,>).Assembly);

            // TODO Add getting hostname from configurations
            var rabbitMqConfigurations = new RabbitConfigurations {HostName = "localhost"};
            collection.AddSingleton<IMessagePublisher>(new RabbitMQPublisher(rabbitMqConfigurations));

            collection.AddScoped<DateTimeProvider>();

            return collection;
        }

        public static void InvokeDatabaseMigrations(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();
           // scope.ServiceProvider.GetService<SPHWriteOnlyContext>().Database.Migrate();
        }
    }
}