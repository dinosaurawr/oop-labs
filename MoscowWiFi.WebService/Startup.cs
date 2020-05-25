using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoscowWiFi.WebService.ApplicationServices.GetAccessPointListUseCase;
using MoscowWiFi.WebService.ApplicationServices.Ports.Gateways.Database;
using MoscowWiFi.WebService.ApplicationServices.Repositories;
using MoscowWiFi.WebService.DomainObjects;
using MoscowWiFi.WebService.DomainObjects.Ports;

namespace MoscowWiFi.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MoscowWiFiContext>(ops => 
                ops.UseSqlite($"Filename={System.IO.Path.Combine(Environment.CurrentDirectory, "MoscowWiFi.db")}"));

            services.AddScoped<ITransportDatabaseGateway, TransportEFSqliteGateway>();

            services.AddScoped<DbAccessPointRepository>();
            services.AddScoped<IReadOnlyAccessPointRepository>(sp => sp.GetRequiredService<DbAccessPointRepository>());
            services.AddScoped<IAccessPointRepository>(sp => sp.GetRequiredService<DbAccessPointRepository>());

            services.AddScoped<IGetAccessPointListUseCase, GetAccessPointListUseCase>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}