using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WPFAspire.BusinessInterfaces;
using WPFAspire.BusinessLogic.Services;
using WPFAspire.Database;
using Microsoft.EntityFrameworkCore;

namespace WPFAspire.WebApi
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
            services.AddDbContext<AspireDbContext>(options => options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Aspire;Trusted_Connection=True;"));
            services.AddScoped<IContactService, ContactServicecs>();
            services.AddMvc();
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
    }
}
