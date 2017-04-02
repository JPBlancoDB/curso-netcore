using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Curso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()  
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup(Assembly.GetEntryAssembly().FullName)
                .Build();

            host.Run();
        }
    }
}
