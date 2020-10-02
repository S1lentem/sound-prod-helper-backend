using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoundProdHelper.Application.Write;
using SoundProdHelper.DI.Write;
using SoundProdHelper.ServiceConfiguration;

namespace SoundProdHelper.Web.Write
{
    public class Startup
    {
        private readonly ServiceBuilder _serviceBuilder;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _serviceBuilder = new ServiceBuilder(configuration, typeof(ApplicationDescriptor));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAllServices(Configuration);
            _serviceBuilder.AddBaseServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _serviceBuilder.SetupMiddlewarePipeline(app, env);

            app.InvokeDatabaseMigrations();
        }
    }
}
