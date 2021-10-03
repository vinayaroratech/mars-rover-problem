using Microsoft.Extensions.DependencyInjection;

namespace MarsRoverProblem
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services)
        {
            services.AddTransient<IPosition, Position>();
            services.AddSingleton<IInMemoryPositionStore, InMemoryPositionStore>();
            return services;
        }
    }
}