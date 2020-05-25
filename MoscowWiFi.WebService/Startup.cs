using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoscowWiFi.WebService.ApplicationServices.GetAccessPointListUseCase;
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
            services.AddScoped(sp => new InMemoryAccessPointRepository(
                new List<AccessPoint>
                {
                    new AccessPoint()
                    {
                        District = "123",
                        Location = "123",
                        Password = "123",
                        Name = "123",
                        AccessFlag = "asda",
                        AdmArea = "asdasd",
                        CoverageArea = 400,
                        FunctionFlag = "asdasd",
                        WiFiName = "asda",
                        NumberOfAccessPoints = 2,
                        Id = 1
                    },
                    new AccessPoint()
                    {
                        District = "123",
                        Location = "123",
                        Password = "123",
                        Name = "123",
                        AccessFlag = "asda",
                        AdmArea = "asdasd",
                        CoverageArea = 400,
                        FunctionFlag = "asdasd",
                        WiFiName = "asda",
                        NumberOfAccessPoints = 3,
                        Id = 2
                    },
                    new AccessPoint()
                    {
                        District = "123",
                        Location = "123",
                        Password = "123",
                        Name = "123",
                        AccessFlag = "asda",
                        AdmArea = "asdasd",
                        CoverageArea = 400,
                        FunctionFlag = "asdasd",
                        WiFiName = "asda",
                        NumberOfAccessPoints = 3,
                        Id = 3
                    },
                }));
            services.AddScoped<IReadOnlyAccessPointRepository>(sp => sp.GetRequiredService<InMemoryAccessPointRepository>());
            services.AddScoped<IAccessPointRepository>(sp => sp.GetRequiredService<InMemoryAccessPointRepository>());

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