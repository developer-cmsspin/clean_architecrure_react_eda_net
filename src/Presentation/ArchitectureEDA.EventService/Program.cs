using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ArchitectureEDA.Application;
using ArchitectureEDA.Domain;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Infrastructure;
using ArchitectureEDA.Infrastructure.Persistence;


var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddConfiguration(configuration);
    })
    .ConfigureServices(services =>
    {
        services.AddApplication()
            .AddDomain()
            .AddInfrastructure()
            .AddPersitence(configuration);
    })
    .Build();


var dispacher = host.Services.GetService<IKafka>();
ArgumentNullException.ThrowIfNull(dispacher);
dispacher.Build();


Console.WriteLine("welcome to Age to EDA");

host.Run();




