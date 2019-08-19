using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

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
                .UseKestrel(options => options.ListenAnyIP(int.Parse(Environment.GetEnvironmentVariable("PORT"))))
                .UseStartup<Startup>()
                .CaptureStartupErrors(true);//to handle exception in startup
    }
}
