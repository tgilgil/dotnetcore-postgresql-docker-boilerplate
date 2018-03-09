using Boilerplate.API.Database;
using Boilerplate.API.Database.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.API
{
    public class Startup
    {
        private string _connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SetupDatabase();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PokemonsContext>(opts => opts.UseNpgsql(_connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void SetupDatabase()
        {
            _connectionString = Configuration["DbContextSettings:ConnectionString"];

            // Use Heroku's injected connection string instead of appsettings' if present
            if (HerokuConfiguration.IsAvailable())
            {
                _connectionString = HerokuConfiguration.GetConnectionString();
            }

            // If this configuration key has been injected, it means Startup is being called by the dotnet cli command
            // and we do not want to migrate the database during that process.
            //if (Configuration["EFToolBeingUsed"] != "true")
            //{
            //    MigrateDabatase();
            //}
        }
    }
}
