using Microsoft.OpenApi.Models;

namespace Consuming_api.Extensions {
    public static class SwaggerExtensions {

        public static void AddSwagger(this IServiceCollection services, IConfiguration config) {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Titulo chat gpt api info",
                    Version = "v1"
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        public static void UseSwaggerDoc(this IApplicationBuilder appBuilder) {
            appBuilder.UseSwagger();
            appBuilder.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CHatGpt Com .net 8");
                c.RoutePrefix = "swagger";
            });
        }

    }
}
