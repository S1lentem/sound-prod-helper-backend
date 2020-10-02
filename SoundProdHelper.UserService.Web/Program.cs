using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SoundProdHelper.UserService.Web
{
    public class Program
    {
        private const string ApplicationPortSectionName = "ApplicationPort";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel((context, options) =>
                    {
                        var applicationPort = int.Parse(context.Configuration[ApplicationPortSectionName]);
                        options.Listen(IPAddress.Any, applicationPort);
                    });
                });
    }
}
