using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DistripackAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .CaptureStartupErrors(true);//to handle exception in startup
    }
}
