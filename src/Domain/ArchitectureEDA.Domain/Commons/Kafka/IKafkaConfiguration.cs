using System;
using Confluent.Kafka;

namespace ArchitectureEDA.Domain.Common.Kafka;

public interface IKafkaConfiguration
{
    string StrapServers  { get; set; }
    string GroupId { get; set; }
    ConsumerConfig GetConfiguration();
}

