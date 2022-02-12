using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using entityFrameworkTest.Services;

namespace entityFrameworkTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string jsonOrder = args[0];



            var host = CreateHostBuilder(args).Build();

            var processor = host.Services.GetRequiredService<Services.IGolgiOrderProcessor>();
            var result = processor.Process(jsonOrder);

            if (result.HasError())
            {
                result.Errors.ForEach(c => Console.WriteLine(c.Message));
            }
            else
            {
                Console.WriteLine($"The mean yield to produce {result.Result.Order} is {result.Result.GetMeanYield()}");

                await using (var scope = host.Services.CreateAsyncScope())
                {
                    var bulkService = scope.ServiceProvider.GetRequiredService<IBulkAssemblingDataService>();
                    await bulkService.BulkAssemblingData(result.Result);
                }
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                        .ConfigureAppConfiguration((hostContext, config) =>
                        {
                            config.AddJsonFile(Path.Combine(Path.Combine(hostContext.HostingEnvironment.ContentRootPath, "Configuration"), "settings.json"));
                            config.AddEnvironmentVariables();
                            if (args != null)
                                config.AddCommandLine(args);

                        })
                        .ConfigureServices((hostContext, services) =>
                        {
                            services.AddAutoMapper(typeof(Program));
                            //services.AddApplicationServices(hostContext.Configuration);
                        })
                        .ConfigureLogging((hostContext, logging) =>
                        {
                            logging.AddConsole();
                        });

        }


    }
}
