using filmesLand_api.Repositories;
using filmesLand_api.Services;
using filmesLand_api.Shared.Context;

namespace filmesLand_api.Shared.ServicesExtensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfiguration>(config);
            services.AddUseCases();
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            return services
                .AddScoped<DbConnectionFactory>()
                .AddFilmeServices();
        }

        public static IServiceCollection AddFilmeServices(this IServiceCollection services)
        {
            return services
                .AddScoped<FilmesRepository>()
                .AddScoped<FilmesService>();
        }
    }
}