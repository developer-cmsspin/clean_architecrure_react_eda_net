using System;
using AutoMapper;
using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ArchitectureEDA.Application.Commons.Kafka.Internal;
using ArchitectureEDA.Domain.Common.Kafka;
using Spin.Helper.Extend;
using static iTextSharp.text.pdf.AcroFields;

namespace ArchitectureEDA.Application.Commons.Kafka;

public class Kafka: IKafka
{
    private readonly IKafkaConfiguration _configuration;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IServiceProvider _serviceProvider;


    public Kafka(IKafkaConfiguration configuration, IMediator mediator, IMapper mapper, IServiceProvider serviceProvider)
    {
        _configuration = configuration;
        _mediator = mediator;
        _mapper = mapper;
        _serviceProvider = serviceProvider;
    }

    public void Build()
    {
        foreach (var eventKafka in KafkaHandlerList.GetEvents())
        {
            KafkaDispacher instance = this._serviceProvider.GetService<KafkaDispacher>();
            ArgumentNullException.ThrowIfNull(instance);
            instance.Build(eventKafka.Key, eventKafka.Value);
            instance.Subscribe();
        }
    }

    public Task Send(string topic, object value)
     => Task.Factory.StartNew(async () =>
     {
         using (var producer = new ProducerBuilder<Null, string>(_configuration.GetConfiguration()).Build())
         {
             await producer.ProduceAsync(topic, new Message<Null, string> { Value = value.ToSerializeJSON() });
         }
         /*
         var kafkaEdaType =KafkaHandlerList.GetKafkaType(topic);
         IKafkaEda instance = this._serviceProvider.GetService(kafkaEdaType) as IKafkaEda;
         instance.Send(value);
         */

     });


}

