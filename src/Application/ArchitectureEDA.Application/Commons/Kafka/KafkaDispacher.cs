using System;
using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using ArchitectureEDA.Application.Commons.Kafka.Commons;
using ArchitectureEDA.Domain.Common.Kafka;

namespace ArchitectureEDA.Application.Commons.Kafka
{
    public class KafkaDispacher
    {
        private readonly IServiceProvider _serviceProvider;
        protected readonly IKafkaConfiguration _configuration;
        private readonly List<KafkaEdaBase> _events;
        public string Topic { get; set; }


        public KafkaDispacher(IServiceProvider serviceProvider, IKafkaConfiguration configuration)
        {
            this._serviceProvider = serviceProvider;
            this._configuration = configuration;
            this._events = new();
        }

        public void Build(string topic, List<Type> eventTypes)
        {
            this.Topic = topic;
            var listEvent = new List<IKafkaEvent>();

            foreach (var itemEvent in eventTypes)
            {
                var instance = this._serviceProvider.GetService(itemEvent);
                ArgumentNullException.ThrowIfNull(instance);

                this._events.Add((KafkaEdaBase)instance);
            }
        }


        public virtual Task Subscribe()
           => Task.Factory.StartNew(() =>
           {
               CreateTopic();
               using (var consumer = new ConsumerBuilder<Ignore, string>(_configuration.GetConfiguration()).Build())
               {
                   bool cancelled = false;

                   consumer.Subscribe(this.Topic);
                   CancellationToken cancellationToken = new();

                   while (!cancelled)
                   {
                       var consumeResult = consumer.Consume(cancellationToken);
                       foreach (var itemEvent in this._events)
                           itemEvent.Handler(consumeResult);
                   }

                   consumer.Close();
               }
           });




        public virtual async void CreateTopic()
        {
            using (var adminClient = new AdminClientBuilder(_configuration.GetConfiguration()).Build())
            {
                try
                {
                    adminClient.GetMetadata(this.Topic, new TimeSpan(0, 1, 0));
                    /*
                    if(metadata.Topics.FirstOrDefault().Error.IsError)
                        await adminClient.CreateTopicsAsync(new TopicSpecification[] {
                            new TopicSpecification { Name = this.Topic, ReplicationFactor = 1, NumPartitions = 1 } });
                    */
                }
                catch (CreateTopicsException e)
                {
                    Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
                }
            }
        }

    }


}

