using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SoundProdHelper.Common.Extensions;

namespace SoundProdHelper.ServiceConfiguration
{
    public class ServiceBuilder
    {
        private readonly SwaggerConfig _swaggerConfig;
        private readonly Type _appCoreType;

        public ServiceBuilder(IConfiguration configuration, Type appCoreType)
        {
            _swaggerConfig = new SwaggerConfig(configuration["ApplicationName"]);
            _appCoreType = appCoreType.ThrowIfNull(nameof(appCoreType));
        }

        public void AddBaseServices(IServiceCollection collection)
        {
            collection.AddSwaggerGen(c =>
                c.SwaggerDoc(_swaggerConfig.Version,
                    new OpenApiInfo {Title = _swaggerConfig.Title, Version = _swaggerConfig.Version}));

            collection.AddMediatR(_appCoreType.Assembly);
            collection.AddAutoMapper(_appCoreType.Assembly);
        }

        public void SetupMiddlewarePipeline(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(_swaggerConfig.Url, _swaggerConfig.Name));
        }
    }
}