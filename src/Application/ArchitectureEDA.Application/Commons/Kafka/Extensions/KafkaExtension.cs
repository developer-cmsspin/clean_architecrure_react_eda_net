using System;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ArchitectureEDA.Domain.Common.Kafka;
using Schema.NET;
using ArchitectureEDA.Application.Commons.Kafka.Internal;

namespace ArchitectureEDA.Application.Commons.Kafka.Extensions
{
    /// <summary>
    /// Extension Kafka
    /// </summary>
    public static class KafkaExtension
    {
        /// <summary>
        /// Add Application
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddKafka(this IServiceCollection services, params Assembly[] assemblies)
        {
            var type = typeof(IKafkaEvent);
            List<string> assemblyName = new();
            assemblyName.Add(assemblies[0].FullName);
            assemblyName.AddRange(assemblies[0].GetReferencedAssemblies().Select(a => a.FullName));

            foreach (var name in assemblyName)
                foreach (var itemAssembly in Assembly.Load(name).GetTypes().Where(a => type.IsAssignableFrom(a) && a.IsClass))
                {
                    KafkaHandlerList.Add(itemAssembly);
                    services.AddTransient(itemAssembly);
                }
                    
                
            return services;
        }
    }
}

