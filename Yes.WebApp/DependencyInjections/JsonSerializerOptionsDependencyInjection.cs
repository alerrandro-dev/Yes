using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yes.WebApp.DependencyInjections;

public static class JsonSerializerOptionsDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddJsonSerializerOptionsDependencyInjection()
        {
            var options = new JsonSerializerOptions();
            var jsonUnionTypeStructuralClassifier = new JsonUnionTypeStructuralClassifier();
            options.TypeClassifiers.Add(jsonUnionTypeStructuralClassifier);
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            services.AddSingleton(options);

            return services;
        }
    }
}
