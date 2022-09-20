using System;
namespace ArchitectureEDA.Domain.Common.Kafka;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class KafkaTopicAttribute : Attribute
{
    public string Topic { get; private set; }
    public KafkaTopicAttribute(string topic)
    {
        Topic = topic;
    }
}

