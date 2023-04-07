using LetsCalc.API.Helper;
using LetsCalc.Database;
using Microsoft.OpenApi.Models;

namespace LetsCalc.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LetsCalc Api", Version = "v1" });
            });
            
            
            services.Configure<JwtSettings>(Configuration.GetSection("Token"));

            AuthStartup.ConfigureJwtAuth(services, Configuration);
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserData, UserData>();
            
            services.AddRazorPages();
            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LetsCalc Api v1"));
            }

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=LetsCalc}/{action=Index}")
                    .RequireAuthorization();
                endpoints.MapRazorPages();
            });
        }
    }
}