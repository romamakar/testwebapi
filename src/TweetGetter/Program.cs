using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace TweetGetter
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // BuildWebHost(args).Run();

            var config = new ConfigurationBuilder()
                        .AddCommandLine(args)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                        .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                  .UseKestrel()
                  .UseUrls("http://localhost:5000/")
                  .ConfigureLogging((hostingContext, logging) =>
                  {
                      logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                      logging.AddConsole();
                      logging.AddDebug();
                  })
                  .Build();

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
                  .UseStartup<Startup>()
                  .UseKestrel()
                  .UseUrls("http://localhost:5000/")
                  .ConfigureLogging((hostingContext, logging) =>
                   {
                       logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                       logging.AddConsole();
                       logging.AddDebug();
                   })
                  .Build();
    }
}
