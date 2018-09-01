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
using HeroesVsDragons.Model.Shared;
using HeroesVsDragons.Model.Database.Services.API;
using HeroesVsDragons.Model.Database.Services.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using HeroesVsDragons.Model.Database.Options;

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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

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

            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IHeroService, HeroService>();
            services.AddTransient<IDragonService, DragonService>();
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

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
