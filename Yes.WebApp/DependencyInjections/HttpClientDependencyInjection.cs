namespace Yes.WebApp.DependencyInjections;

public static class HttpClientDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddHttpClientDependencyInjection()
        {
            var httpClient = new HttpClient();
            var uri = new Uri("http://localhost:5200/api/");
            httpClient.BaseAddress = uri;

            services.AddSingleton(httpClient);

            return services;
        }
    }
}
