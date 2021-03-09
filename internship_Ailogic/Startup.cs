using AutoMap;
using Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository.Repository;
using System;
using System.Reflection;

namespace internship_Ailogic
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200", "http://apirequest.io", "https://reqbin.com")
                                                                                        .AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()
;
                                  });
            });
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores <bnbar022dce4hrtds2xdContext>();
            services.AddDbContext<bnbar022dce4hrtds2xdContext>(options => options.UseMySql(Configuration.GetConnectionString("Default"))); 
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "internship_Ailogic", Version = "v1" });
            });
            services.AddScoped<RequestInternshipRepository>();
            services.AddScoped<InternshipsRepository>();
            services.AddScoped<InternRepository>();


            services.AddAutoMapper(typeof(Automapping).GetTypeInfo().Assembly);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors(options => options.AllowAnyOrigin());

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "internship_Ailogic v1");
            //    c.RoutePrefix = string.Empty;

            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "internship_Ailogic v1");

                });

            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
