using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaPermiso.Infraestructure.Data.Context;
using SistemaPermiso.Core.Services;
using SistemaPermiso.Core.Interface;
using SistemaPermiso.Infraestructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using SistemaPermiso.Infraestructure.Mapping;

namespace SistemaPermiso
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //DataBase Conection
            services.AddDbContext<PermmisionContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("PermmisionConexion")
                ).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient);

            //AUTOMAPPER CONFIGURATION
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);



            services.AddMvc();

            //add cors header and other origin access frond end
            services.AddCors(options => options.AddPolicy("Permisos",
                builder => builder.AllowAnyHeader()
                                  .AllowAnyOrigin()
                                  .AllowAnyMethod()
                ));

            //MidelWare app
            services.AddTransient<IPermmisionServices, PermmisionServices>();
            services.AddTransient<IPermmisionTypeServices, PermmisiontypeServices>();
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddControllers();

            //add Swagger
            services.AddSwaggerGen();
            //services.AddSwaggerGen(options =>
            //options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            //{
            //    Title = "Sistema Permiso",
            //    Version = "v1"
            //}));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
         

            //app Cors
            app.UseCors("Permisos");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema Permisos V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=PermmissionType}/{action=GetAll}");
            });
        }
    }
}
