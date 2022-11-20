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
    }
}
