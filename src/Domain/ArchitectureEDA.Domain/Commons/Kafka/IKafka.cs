using System;
namespace ArchitectureEDA.Domain.Common.Kafka;

public interface IKafka
{
    Task Send(string topic, object value);
    void Build();
}

