using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SoundProdHelper.Domain.Contracts;
using SoundProdHelper.ServiceConfiguration;
using SoundProdHelper.UserService.Application;
using SoundProdHelper.UserService.DI;

namespace SoundProdHelper.UserService.Web
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

            var authenticationKey = Configuration["Authentication:key"];

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authenticationKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            _serviceBuilder.AddBaseServices(services);
            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _serviceBuilder.SetupMiddlewarePipeline(app, env);
        }
    }
}
