using Microsoft.Extensions.DependencyInjection;

namespace Demo.UI.Navigation;

/// <summary>
/// Provides extension methods for configuring services.
/// </summary>
internal static class DependencyExtensions
{
    /// <summary>
    /// Configures the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The configured service collection.</returns>
    internal static IServiceCollection Configure(this IServiceCollection services)
    {
        return services;
    }
}
