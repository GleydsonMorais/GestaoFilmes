using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoFilmesAPI.Data.Contexts;
using GestaoFilmesAPI.Data.Repositories;
using GestaoFilmesAPI.Interfaces;
using GestaoFilmesAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GestaoFilmesAPI
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
            services.AddDbContext<GestaoFilmesAPIDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Add application services.
            services.AddTransient<IGeneroService, GeneroService>();
            services.AddTransient<IFilmeService, FilmeService>();

            services.AddTransient<IGeneroRepository, GeneroRepository>();
            services.AddTransient<IFilmeRepository, FilmeRepository>();

            services.AddSwaggerGen(options => {

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gestão de Filmes",
                    Version = "v1",
                    Description = "API REST criada com o ASP.NET Core 3.1 para gerenciamento de Filmes"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddFile("./Logs/myapp-{Date}.txt");

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestão de Filmes V1");
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
