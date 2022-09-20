using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Infrastructure.Persistence.Repository;
using ArchitectureEDA.Infrastructure.Persistence.Configuration;
using Microsoft.Extensions.Configuration;
using ArchitectureEDA.Infrastructure.Persistence.Context;

namespace ArchitectureEDA.Infrastructure.Persistence;

/// <summary>
/// dependency inyection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Add Persistence
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddPersitence(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.Configure<StateDatabaseSettings>(configuration.GetSection("StateDatabase"));
        services.Configure<ErrorDatabaseSettings>(configuration.GetSection("ErrorDatabase"));
        services.Configure<SessionDatabaseSettings>(configuration.GetSection("SessionDatabase"));

        services.AddTransient<StateContext>();
        services.AddTransient<ErrorContext>();
        services.AddTransient<SessionContext>();

        services.AddTransient<IRepositoryState, RepositoryState>();
        services.AddTransient<IRepositoryError, RepositoryError>();
        services.AddTransient<IRepositorySession, RepositorySession>();

        return services;
    }
}

