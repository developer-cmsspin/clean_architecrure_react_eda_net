using System;
using AutoMapper;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using MediatR;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Dto.Availability;
using Org.BouncyCastle.Crypto;
using Spin.Helper.Extend;

namespace ArchitectureEDA.Application.Commons.Kafka.Commons;

public abstract class KafkaEdaBase
{
    protected readonly IKafkaConfiguration _configuration;

    public KafkaEdaBase(IKafkaConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string[] Topic
    {
        get
        {
            return NameGetter.For(this.GetType());
        }
    }

    /*
    public virtual async void Send(object value)
    {
        using (var producer = new ProducerBuilder<Null, string>(_configuration.GetConfiguration()).Build())
        {
            await producer.ProduceAsync(this.Topic, new Message<Null, string> { Value = value.ToSerializeJSON() });
        }
    }
    */

    public abstract Task Handler(ConsumeResult<Ignore, string> result);
}


