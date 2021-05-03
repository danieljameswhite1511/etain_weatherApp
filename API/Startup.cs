using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using API.Helpers;
using API.Middleware;
using API.Extensions;
using Infrastructure.Identity;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        //public IConfiguration Configuration { get; }

        // Services
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();

            services.AddSwaggerDocumentation();

            services.AddDbContext<DataContext>(x => x.UseSqlite(_config.GetConnectionString("SQLiteConnection")));

            services.AddDbContext<AppIdentityDbContext>(x => x.UseSqlite(_config.GetConnectionString("SQLiteIdentityConnection")));

            services.AddApplicationServices();

            services.AddIdentityServices(_config);

            services.AddCors(opt => {

                opt.AddPolicy("CorsPolicy", policy =>{
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });

            });
        }

        // Middleware
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
               app.UseSwaggerDocumentation();
            }

            //Adds the exception Middleware
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}