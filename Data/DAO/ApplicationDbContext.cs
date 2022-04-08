using Brain.Dev.GStock.Metier.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Brain.Dev.GStock.Data.DAO
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILogger<ApplicationDbContext> logger;
        private readonly ConnectionStrings connectionStrings;
        private readonly AppSettings appSettings;
        //private readonly string ConnectionStringName= "DefaultConnection";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, 
            IOptions<ConnectionStrings> connectionStrings, 
            IOptions<AppSettings> appsettings, ILogger<ApplicationDbContext> logger) : base(options)
        {
            this.logger = logger;
            this.connectionStrings = connectionStrings.Value;
            this.appSettings = appsettings.Value;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //    if (string.IsNullOrWhiteSpace(environment))
        //        throw new Exception("Missing environment name from configuration, check your launchSettings.json and try again.");//environment = "Production";//

        //    var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        //                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //                                .AddJsonFile($"appsettings.{environment.ToLowerInvariant()}.json", optional: true)
        //                                .AddEnvironmentVariables()
        //                                .Build();

        //    if (configuration == null)
        //    {
        //        logger.LogInformation($"Failed to build configuration [ '{environment}' environment ]");
        //        throw new Exception("Failed to build configuration");
        //    }


        //    //var useInMemory = _forceInMemory || (bool.TryParse(Environment.GetEnvironmentVariable("GS_Database__InMemory"), out bool inMemoryConfig) && inMemoryConfig);
        //    //logger.LogInformation($"Configuring database context for '{environment}' environment (Use in memory db: useInMemory)");

        //    //if (useInMemory)
        //    //    return;

        //    var connectionString = configuration.GetConnectionString(ConnectionStringName);
        //    connectionString = this.connectionStrings.DefaultConnectionString;
        //    if (string.IsNullOrWhiteSpace(connectionString))
        //    {
        //        logger.LogError($"Could not find/read connection string '{ConnectionStringName}', make sure it's properly set in the configuration.");
        //        return;
        //    }

        //    builder.UseMySQL(connectionString, options => options.MigrationsAssembly("api.ccg.rezo509.com"));
        //    base.OnConfiguring(builder);
        //}

        public DbSet<CategoryModel> Categories { get; set; }
    }
}
