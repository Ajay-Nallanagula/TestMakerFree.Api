using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace TestMakerFree.Api
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
            services.AddMvc();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Info {
                    Version = "v1",
                    Title = "My API",
                    Description = ".net core api with swagger support",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Ajay Nallanagula", Email = "kumarnajay9@gmail.com", Url = "www.google.com" }
                });

                //swagger.SwaggerDoc("v2", new Info
                //{
                //    Version = "v2",
                //    Title = "My API",
                //    Description = ".net core api with swagger support",
                //    TermsOfService = "None",
                //    Contact = new Contact() { Name = "Ajay Nallanagula", Email = "kumarnajay9@gmail.com", Url = "www.google.com" }
                //});
            });
            services.AddCors(options => {
                options.AddPolicy("AllowSpecificPolicy",
                    build => build.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowSpecificPolicy");
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(swagUI => {
                swagUI.SwaggerEndpoint("/swagger/v1/swagger.json","TestMakerFree.ApiV1");
                //swagUI.SwaggerEndpoint("/swagger/v2/swagger.json", "TestMakerFree.ApiV2");
            });
        } 
    }
}
