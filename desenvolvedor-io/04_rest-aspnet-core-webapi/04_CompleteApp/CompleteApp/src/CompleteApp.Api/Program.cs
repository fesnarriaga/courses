using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CompleteApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.ConfigureLogging((ctx, logging) =>
                    //{
                    //    logging.AddElmahIo(options =>
                    //    {
                    //        options.ApiKey = "da66bc2b08114e5ebc9420da61d1851b";
                    //        options.LogId = new Guid("7201e0da-0106-4b7e-bed1-82b39333479f");
                    //    });

                    //    logging.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
                    //});
                });
    }
}
