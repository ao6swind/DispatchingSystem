using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DbContexts;
using Backend.Seeders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Backend
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
            var connection = @"Server=(LocalDb)\MSSQLLocalDB;Database=DbDispatchingSystem;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<DbDispatchingSystem>(options => options.UseSqlServer(connection));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbDispatchingSystem context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // 相依性注入DbContext後，讓每次開啟應用都自動進行Migrate
            context.Database.Migrate();
            // 撒入預設的資料
            DbInit.Initialize(context);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
