using ElgamalSandbox.Core.Abstractions;
using ElgamalSandbox.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ElgamalSandbox.Core
{
    public static class Entry
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(typeof(Entry).Assembly));
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}