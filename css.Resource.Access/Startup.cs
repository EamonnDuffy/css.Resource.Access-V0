using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using css.Resource.Access.BusinessEngines;
using css.Resource.Access.Handlers;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace css.Resource.Access
{
    public class Startup
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private void ConfigureLogging()
        {
            try
            {
                var entryAssembly = Assembly.GetEntryAssembly();

                var assemblyPath = Path.GetDirectoryName(entryAssembly.Location);

                var logRepository = LogManager.GetRepository(entryAssembly);

                using (var fileStream = File.Open(Path.Combine(assemblyPath, "Log4Net.config"), FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var collection = XmlConfigurator.Configure(logRepository, fileStream);
                }

                Log.Info("The Application is starting...");
            }
            catch (Exception exception)
            {
                int breakPoint = 1;
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPingHandler, PingHandler>();
            services.AddTransient<ISessionsHandler, SessionsHandler>();

            services.AddTransient<ISessionsBusinessEngine, SessionsBusinessEngine>();

            services.AddControllers()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureLogging();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
