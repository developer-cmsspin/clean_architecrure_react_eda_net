using System;
using AutoMapper;
using Confluent.Kafka;
using MediatR;
using ArchitectureEDA.Application.Commons.Kafka.Commons;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Model.State.Availability;
using Spin.Helper.Extend;

namespace ArchitectureEDA.EventService.Services.Availability
{
    [KafkaTopicAttribute(AvailabilityEvent.AVAILABILITY_REPLY)]
    public class AvailabilityReplyService: KafkaEdaBase, IKafkaEvent
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public AvailabilityReplyService(IKafkaConfiguration configuration, IMediator mediator, IMapper mapper)
        : base(configuration)
        {
            this._mapper = mapper;
            this._mediator = mediator;
        }

        public override Task Handler(ConsumeResult<Ignore, string> result)
         => Task.Factory.StartNew(() =>
         {
             //var request = result.Message.Value.ToDeserializeJSON<AvailabilityState>();
             //_mediator.Send(request);
         });
    }
}

