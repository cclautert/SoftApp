﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SoftApp.Domain.Entities;
using SoftApp.Domain.Interfaces;
using SoftApp.Domain.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace SoftApp.Calcula.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IJurosService, JurosService>();            

            var configApp = new ConfigApp();
            Configuration.Bind("ConfigApp", configApp);
            services.AddSingleton(configApp);
            
            services.AddApiVersioning(v =>
            {
                v.ReportApiVersions = true;
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1.0", new Info
                {
                    Title = "Calcula Juros",
                    Description = "Seleção de pessoa Desenvolvedora .Net Core",
                    Version = "v1.0",
                    Contact = new Contact
                    {
                        Name = "Cristiano Claudson Lautert",
                        Email = "cristiano.c.lautert@gmail.com",
                        Url = "https://github.com/cclautert"
                    }
                });
                s.SwaggerDoc("v2.0", new Info
                {
                    Title = "Obtem Taxa",
                    Description = "Seleção de pessoa Desenvolvedora .Net Core",
                    Version = "v2.0",
                    Contact = new Contact
                    {
                        Name = "Cristiano Claudson Lautert",
                        Email = "cristiano.c.lautert@gmail.com",
                        Url = "https://github.com/cclautert"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger(s => s.RouteTemplate = "doc/{documentName}/doc.json");
            app.UseSwaggerUI(su =>
            {
                su.SwaggerEndpoint("/doc/v1.0/doc.json", "SoftApp V1.0");
                su.SwaggerEndpoint("/doc/v2.0/doc.json", "SoftApp V2.0");
                su.RoutePrefix = "doc";
            });

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
