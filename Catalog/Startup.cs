using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Catalog.Repository;
using Catalog.Models;
using Catalog.Events;
using Microsoft.Extensions.Logging;


namespace Catalog
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IProductRepository, ProductMemoryRepository>();

            services.AddSingleton<AMQPOptions>();
            services.AddSingleton(typeof(IEventEmitter), typeof(AMQPEventEmitter));
            services.AddSingleton(typeof(ICommandEventConverter), typeof(CommandEventConverter));
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IEventEmitter eventEmitter)
        {
            // Asked for instances of singletons during Startup
            // to force initialization early.
            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new List<string> { "index.html" }
            });

            app.UseMvc();
        }

    }
}
