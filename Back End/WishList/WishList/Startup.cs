using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishList
{
    public class Startup
    {
        readonly string CorsPolicy = "_corsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()

            .AddNewtonsoftJson(options =>
             {
                 // Ignora os loopings nas consultas

                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                 // Ignora valores nulos ao fazer jun??es nas consultas

                 options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
             });

            services.AddCors(options => {
                options.AddPolicy(CorsPolicy,
                    builder => {
                        builder.WithOrigins("http://localhost:3000")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(CorsPolicy);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
