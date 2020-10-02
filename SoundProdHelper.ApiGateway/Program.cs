using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SoundProdHelper.ApiGateway
{
    public class Program
    {
        private const string ApplicationPortSectionName = "ApplicationPort";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureKestrel((context, options) =>
                        {
                            var port = int.Parse(context.Configuration[ApplicationPortSectionName]);
                            options.Listen(IPAddress.Any, port);
                        });
                });
    }
}
