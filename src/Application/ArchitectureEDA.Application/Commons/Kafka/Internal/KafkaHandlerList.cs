using ArchitectureEDA.Domain.Common.Kafka;

namespace ArchitectureEDA.Application.Commons.Kafka.Internal
{
    internal static class KafkaHandlerList
    {
        private readonly static Dictionary<string, List<Type>> _kafkaEvent = new();

        public static void Add(Type kafkaEdaType)
        {
            var topicsApply = NameGetter.For(kafkaEdaType);
            foreach (var topic in topicsApply)
            {
                if (!_kafkaEvent.ContainsKey(topic))
                    _kafkaEvent.Add(topic, new());

                _kafkaEvent[topic].Add(kafkaEdaType);
            }
        }

        /*
        public static Type GetKafkaType(string topic)
            => (_kafkaEvent.ContainsKey(topic)) ? _kafkaEvent[topic] : throw new ArgumentNullException("Not contain topic " + topic);
        */

        public static Dictionary<string, List<Type>> GetEvents()
         => _kafkaEvent;
    }
}

