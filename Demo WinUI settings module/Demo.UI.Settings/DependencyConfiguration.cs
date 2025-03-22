using System;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.UI.Settings;

/// <summary>
/// Provides methods for configuring and retrieving services.
/// </summary>
public static class DependencyConfiguration
{
    /// <summary>
    /// Gets or sets the service provider.
    /// </summary>
    public static ServiceProvider? Services { get; set; }

    /// <summary>
    /// Configures the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    public static void Configure(ServiceCollection services)
    {
        services.Configure();
    }

    /// <summary>
    /// Gets the specified service.
    /// </summary>
    /// <typeparam name="T">The type of service to get.</typeparam>
    /// <returns>The requested service.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the service provider is not configured.</exception>
    public static T GetService<T>()
        where T : class
    {
        if (Services == null)
        {
            throw new InvalidOperationException("Services is null");
        }

        return Services.GetRequiredService<T>();
    }
}
