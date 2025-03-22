using Demo.UI.Navigation.ViewModels.UserControls;
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
        services.AddViewModels();
        return services;
    }

    /// <summary>
    /// Adds the view models to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the view models to.</param>
    /// <returns>The service collection with the view models added.</returns>
    internal static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        // User controls
        services.AddTransient<BreadcrumbHeaderViewModel>();
        services.AddTransient<BreadcrumbItemViewModel>();

        return services;
    }
}
