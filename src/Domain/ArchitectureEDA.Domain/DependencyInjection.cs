using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ArchitectureEDA.Domain;

/// <summary>
/// dependency inyection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Add Domain
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}

