
using Api.Extensions;
using CrossCutting.IoC.Config;
using Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication;
using Business.Helpers;
using System;
using Microsoft.AspNetCore.Http.Features;


namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services.AddControllers();
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddDbContext<TestContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.Configure<FormOptions>(x =>
            //{
            //    x.MultipartBodyLengthLimit = 60000000;
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

;

            services.AddAutoMapperSetup();
            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

        }
        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
