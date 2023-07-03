using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using PuertaDeEntrada.Application.Common.Utils;
using PuertaDeEntrada.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PuertaDeEntrada.WebUI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                     context.Database.Migrate(); //EntityFrameworkCore\Update-Database -verbose
                    await host.RunAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration(config =>
                        config.SetBasePath(VariablesUtil.GetDirectoryAppSettings())
                        .AddJsonFile($"appsettings.{env}.json"));
                });
    }
}
