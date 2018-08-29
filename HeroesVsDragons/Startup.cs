using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using HeroesVsDragons.Model.API.Services;
using HeroesVsDragons.Model.Database.Services.API;

namespace HeroesVsDragons
{
    /// <summary>
    /// Some coment.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Some coment.
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Get configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "HeroesVsDragon",
                    Version = "v1",
                });
                //c.OperationFilter<AddEnumOperationFilter>();
                //c.OperationFilter<AuthorizationHeaderOperationFilter>();

                //c.DocumentFilter<SetVersionInPaths>();
#if !TEST
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "HeroesVsDragons.xml");

                c.IncludeXmlComments(xmlPath);
#endif
            });

            services.AddSingleton<IHeroService, HeroService>();
            services.AddScoped<IDragonService, DragonService>();
            //services.AddTransient<IHitService, HitService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HeroesVsDragons V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
