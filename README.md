1) доп проекты: add libraries: HeroesVsDragons.model, HeroesVsDragons.model.Database and test app: HeroesVsDragons.Tests
2) swagger: add nuget 2 package (Swashbuckle.Aspnetcore, Swashbuckle.Aspnetcore.SwaggerUi)

+ на проекте правой кнопкой мыши параметры-сборка-компилятор отметить сформировать док. xml и получим название файла

+ settings in startup.cs.
``````
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
``````

``````
public void ConfigureServices(IServiceCollection services)
        {
        ............
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
``````

``````public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        ..............
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                //c.InjectStylesheet("/swagger-ui/custom.css");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HeroesVsDragons V1");
            });
``````

https://localhost:5001/swagger/index.html

3) Add referense одного проекта на друго на проекте - на зависимостях - добавить ссылку
4) Add interfeces
5) Add model class (vs base)
6) Add apicontrollers class (vs base)
7) Add helpers
8) Add services

``````
services.AddScoped<IHeroService, HeroService>();
........

private readonly IHeroService _itemService;
``````

9) Start use DI
10) Add dragon
11) Clear default controller values and change default route Properties -> launchSettings
12) Add token controller
13) Add class AuthOptions settings
14) Change startup.cs for JWT


Some usage:

* Swagger

* Entity Framework Core

* JSON Web Token (JWT) 
