using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using LogicLib.Services.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Fluent;
using Swashbuckle.AspNetCore.Swagger;
using Web_Api.Exceptions;
using Web_Api.Utils;
using SwaggerOptions = Web_Api.Configuration.SwaggerOptions;


namespace Web_Api.Installers
{
    public class MvcInstaller : IServiceInstaller, IConfigurationInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env,
            ILogger logger)
        {
            services.AddRazorPages();

            services.AddControllers(opts => { })
                .AddNewtonsoftJson();

            services.AddAutoMapper(typeof(Startup));

            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = jwtSettings.PrivateSigningSecretKey,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddSingleton(tokenValidationParameters);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameters;
                });


            services.AddAuthorization(options =>
            {
                options.AddPolicy(Authorizations.RequireAdminOrManagerRole,
                    policy => policy.RequireRole(Authorizations.Admin, Authorizations.Manager));
            });


            services.AddSwaggerGen(x =>
            {
                var swaggerOptions = new SwaggerOptions();
                configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
                x.SwaggerDoc(swaggerOptions.Version,
                    new OpenApiInfo {Title = swaggerOptions.Title, Version = swaggerOptions.Version});
                var secScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using bearer scheme",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                };
                x.AddSecurityDefinition("Bearer", secScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement {{secScheme, new List<string>()}});
            });
        }

        public void InstallConfiguration(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration,
            ILogger logger)
        {
            var swaggerOptions = new SwaggerOptions();
            configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerOptions.UIEndPoint, swaggerOptions.Description);
                options.RoutePrefix = "swagger"; //To serve the Swagger UI at the :http://localhost:<port>/RoutePrefix
            });


            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseRouting();

            var useAuthentication = configuration.GetValue<bool>("UseAuthentication");
            if (useAuthentication)
            {
                logger.LogInformation("Authentication enabled");
                app.UseAuthentication();
            }
            else
            {
                logger.LogInformation("Authentication disabled");
                //on staging/development dont require authentication
                app.Use(async (context, next) =>
                {
                    // Set claims for the test user.
                    var claims = new[] {new Claim("role", "Admin")};
                    var id = new ClaimsIdentity(claims, "DebugAuthorizationMiddleware", "name", "role");
                    // Add the test user as Identity.
                    context.User.AddIdentity(id);
                    // User is now authenticated.
                    await next.Invoke();
                });
            }
            
              
            app.UseStaticFiles();
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
                endpoints.MapRazorPages();
            });
        }
    }
}