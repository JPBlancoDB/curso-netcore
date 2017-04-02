using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Curso
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();

            app.Map("/mapa1", Mapa1);
            
            app.Map("/mapa2", Mapa2);
            
            app.MapWhen(context => context.Request.Query.ContainsKey("mapwhen"), MapWhen);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hola");
            });
        }

        private static void Mapa1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hola mapa 1");
            });
        }

        private static void Mapa2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hola mapa 2");
            });
        }

        private static void MapWhen(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var valor = context.Request.Query["mapwhen"];
                
                if(valor == "map1")
                {
                    await context.Response.WriteAsync($"Se uso el middleware mapwhen1 = {valor}");
                }
                
                else if(valor == "map2")
                {
                    await context.Response.WriteAsync($"Se uso el middleware mapwhen2 = {valor}");
                }
                
                else 
                {
                    await context.Response.WriteAsync($"No se encontro el middleware {valor}.");
                }
            });
        }
    }
}
