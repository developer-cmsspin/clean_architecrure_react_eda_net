using System;
using Confluent.Kafka;

namespace ArchitectureEDA.Domain.Common.Kafka
{
    public interface IKafkaEvent
    {
        string[] Topic { get; }
        Task Handler(ConsumeResult<Ignore, string> result);
    }
}

