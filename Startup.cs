using Brain.Dev.GStock.Data;
using Brain.Dev.GStock.Data.DAO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.ccg.rezo509.com
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
            var connectionStringsSection = Configuration.GetSection("ConnectionStrings");
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            services.Configure<ConnectionStrings>(connectionStringsSection);

            var connectionStrings = connectionStringsSection.Get<ConnectionStrings>();
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //For container
            var server = Configuration["DBServer"] ?? connectionStrings.Server;
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? connectionStrings.UserId;
            var password = Configuration["DBPassword"] ?? connectionStrings.Password;
            var database = Configuration["DBName"] ?? connectionStrings.Database;

            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer($"Server={server};Initial Catalog={database};User ID={user};Password={password}"));
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionStrings.DefaultConnectionString));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api.ccg.rezo509.com [4]", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api.ccg.rezo509.com v1"));
            }
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api.ccg.rezo509.com v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
