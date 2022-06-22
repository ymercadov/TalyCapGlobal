using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Datos.AgenteServicios;
using Microsoft.AspNetCore.Http;
using Datos.Persistencia.Core;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Contratos;
using Aplicacion.Implementacion;
using Dominio.Contratos;
using Datos.Persistencia.Implementacion;
using AutoMapper;
using Aplicacion.Core;
using Aplicacion.Contratos.Contratos;

namespace TalyCapGlobal
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
            services.AddDbContext<ContextoPrincipal>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("ConexionTest")));

            services.AddControllers();
            services.AddAutoMapper(typeof(MapperProfile));
            AddSwagger(services);
            services.Configure<Peticiones>(Configuration.GetSection("Peticiones"));
            services.AddTransient<IFabricaPeticiones, FabricaPeticiones>();
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddTransient<IContextoUnidaDeTrabajo, ContextoPrincipal>();
            services.AddTransient<IBooksServicio, booksServicio>();
            services.AddTransient<IBooksRepositorio, BookRepositorio>();
            services.AddTransient<IAuthorsServicio, authorsServicio>();
            services.AddTransient<IAuthorsRepositorio, AuthorsRepositorio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Libreria API V1");
            });
            
        }


        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Libreria {groupName}",
                    Version = groupName,
                    Description = "Libreria API",
                    Contact = new OpenApiContact
                    {
                        Name = "Libreria Company",
                        Email = string.Empty,
                        Url = new Uri("https://ymercadov.github.io/portafolio-angular/#/home"),
                    }
                });
            });
        }
    }
}
