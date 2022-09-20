using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ArchitectureEDA.Application.Commons.Kafka;
using ArchitectureEDA.Application.Commons.Kafka.Configuration;
using ArchitectureEDA.Application.Commons.Kafka.Extensions;
using ArchitectureEDA.Domain.Common.Kafka;

namespace ArchitectureEDA.Application;

/// <summary>
/// dependency inyection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Add Application
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IKafka, Kafka>();
        services.AddTransient<IKafkaConfiguration, KafkaConfiguration>();
        services.AddTransient<KafkaDispacher>();
        
        services.AddMediatR(Assembly.GetExecutingAssembly()); //Mediator
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); ///Automapper
        services.AddKafka(Assembly.GetEntryAssembly()); // Kafka
        

        return services;
    }
}
