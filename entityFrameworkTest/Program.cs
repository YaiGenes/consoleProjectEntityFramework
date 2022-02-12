using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using entityFrameworkTest.Dto;
//using System.Text.Json;
using Newtonsoft.Json;
using System.Net;

namespace entityFrameworkTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string jsonOrder = args[0];

            var webClient = new WebClient();
            var stringJson = webClient.DownloadString(jsonOrder);
            DataDTO myDeserializedClass = JsonConvert.DeserializeObject<DataDTO>(stringJson);

            //GolgiComplexDto myDeserializedClass = JsonSerializer.Deserialize<GolgiComplexDto>(File.ReadAllText(jsonOrder));

            myDeserializedClass.data.ToList().ForEach(ar => 
            { 
                ar.detail.ToList().ForEach(li=> 
                {
                    li.subcomponents.ToList().ForEach(sub =>
                    {
                        Console.WriteLine(sub.type);
                    }); 
                }); 
            });

            //var host = CreateHostBuilder(args).Build();

            //var processor = host.Services.GetRequiredService<IFabrikOrderProcessor>();
            //var result = processor.Process(jsonOrder);

            //if (result.HasErrors())
            //{
            //    result.Errors.ForEach(c => Console.WriteLine(c.Message));
            //}
            //else
            //{
                //Console.WriteLine($"The order price is {result.Result.GetPrice()}");

                //await using (var scope = host.Services.CreateAsyncScope())
                //{
                    //var bulkService = scope.ServiceProvider.GetRequiredService<IBulkPackageDataService>();
                    //await bulkService.BulkPackageData(result.Result);
                //}
            //}
        }

        //private static IHostBuilder CreateHostBuilder(string[] args)
        //{
        //    return Host.CreateDefaultBuilder(args)
        //                .ConfigureAppConfiguration((hostContext, config) =>
        //                {
        //                    config.AddJsonFile(Path.Combine(Path.Combine(hostContext.HostingEnvironment.ContentRootPath, "Configuration"), "settings.json"));
        //                    config.AddEnvironmentVariables();
        //                    if (args != null)
        //                        config.AddCommandLine(args);

        //                })
        //                .ConfigureServices((hostContext, services) =>
        //                {
        //                    services.AddAutoMapper(typeof(Program));
        //                    //services.AddApplicationServices(hostContext.Configuration);
        //                })
        //                .ConfigureLogging((hostContext, logging) =>
        //                {
        //                    logging.AddConsole();
        //                });

        //}


    }
}
