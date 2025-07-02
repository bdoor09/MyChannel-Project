using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace My_Channel_Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
  
        // This method gets called by the runtime. 
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue; options.MultipartBodyLengthLimit = long.MaxValue; options.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddScoped<NETCore.MailKit.Core.IEmailService, NETCore.MailKit.Core.EmailService>();

        }

        // This method gets called by the runtime.this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
