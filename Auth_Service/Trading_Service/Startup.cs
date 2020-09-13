using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trading_Service.Domain;
using Trading_Service.Domain.IServices;
using Trading_Service.JWT;
using Trading_Service.Persistence;
using Trading_Service.Persistence.Services;
using Trading_Service.Utilities;

namespace Trading_Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StockContext>(opt => opt.UseSqlite(
               Configuration.GetConnectionString("DbConnection")));

            services.AddSingleton<JWTAuthHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStockCompanyService, StockCompanyService>();
            services.AddScoped<IStocksService, StocKService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<ILogWriter, LogWriter>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
