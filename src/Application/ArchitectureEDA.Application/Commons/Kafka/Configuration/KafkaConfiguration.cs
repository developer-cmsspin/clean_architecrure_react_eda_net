using System;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using ArchitectureEDA.Domain.Common.Kafka;

namespace ArchitectureEDA.Application.Commons.Kafka.Configuration;

public class KafkaConfiguration : IKafkaConfiguration
{
    private readonly ConsumerConfig _configuration;

    public KafkaConfiguration(IConfiguration configuration)
    {
        var setting = configuration.GetRequiredSection("Kafka").Get<KafkaSetting>();
        _configuration = new ConsumerConfig
        {
            BootstrapServers = setting.StrapServers,
            GroupId = setting.GroupId,
            AutoOffsetReset = AutoOffsetReset.Earliest,

        };
    }

    public string StrapServers { get => _configuration.BootstrapServers; set => _configuration.BootstrapServers = value; }
    public string GroupId { get => _configuration.GroupId; set => _configuration.GroupId = value; }

    public ConsumerConfig GetConfiguration()
        => this._configuration;
}

