using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void Configure(this SwaggerGenOptions options, string commentsXmlFilePath)
        {
            options.IncludeXmlComments(commentsXmlFilePath);

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "WOK-platform",
                Version = "v1"
            });
        }

        public static void AddSecurity(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        }


    }
}
