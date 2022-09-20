using System;
namespace ArchitectureEDA.Domain.Common.Kafka;

public static class NameGetter
{
    public static string[] For<T>()
    {
        return For(typeof(T));
    }
    public static string[] For(Type type)
    {
        // add error checking ...
        return type.GetCustomAttributes(typeof(KafkaTopicAttribute), false).Select(z => ((KafkaTopicAttribute)z).Topic).ToArray();
    }
}

