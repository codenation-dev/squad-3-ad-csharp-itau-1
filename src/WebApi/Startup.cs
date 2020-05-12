using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using TryLog.WebApi.ExtensionsMethods;
using TryLog.Infraestructure.EF;
using TryLog.Infraestructure.Repository;
using TryLog.Core.Interfaces;
using TryLog.Services.Interfaces;
using TryLog.Services.App;
using TryLog.UseCase.Mapper;
using AutoMapper;
using System.Collections.Generic;
using TryLog.Services;
using TryLog.Services.SettingObjects;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System;
using System.IO;

namespace TryLog.WebApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    });
            services.AddCors();

            services.AddDbContext<TryLogContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TryLogDb")));
            
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "TryLog", 
                    Version = "v1" 
                
                
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            services.AddScoped<IEnvironmentRepository, EnvironmentRepository>();
            services.AddScoped<ILayerRepository, LayerRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ISeverityRepository, SeverityRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<IEnvironmentService, EnvironmentService>();
            services.AddScoped<ILayerService, LayerService>();
            services.AddScoped<ISeverityService, SeverityService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ILogService, LogService>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<EmailService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<AuthenticatedUser>();


            services.AddIdentityConfiguration();

            var tokenConfiguration = Configuration.GetSection("TokenConfigurations");
            services.Configure<TokenSettings>(tokenConfiguration);
            services.AddTokenConfiguration(tokenConfiguration);


            services.AddRouting(opt =>
            {
                opt.LowercaseQueryStrings = false;
                opt.LowercaseUrls = true;
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TryLogContext>();
                context.Database.EnsureCreated();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TryLog");
            });

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
