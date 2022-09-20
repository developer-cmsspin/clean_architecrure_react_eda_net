using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ArchitectureEDA.Domain.Interfaces.Infrastructure.Availability;
using ArchitectureEDA.Infrastructure.Availability;

namespace ArchitectureEDA.Infrastructure;

/// <summary>
/// dependency inyection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Add Infrastructure
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IProviderOneInfrastructure, ProviderOneInfrastructure>();
        services.AddTransient<IProviderTwoInfrastructure, ProviderTwoInfrastructure>();

        return services;
    }
}

