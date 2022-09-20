using System;
using AutoMapper;
using Confluent.Kafka;
using MediatR;
using ArchitectureEDA.Application.Commons.Kafka.Commons;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Model.AvailabilityOne;
using ArchitectureEDA.Domain.Model.State.Availability;
using Spin.Helper.Extend;

namespace ArchitectureEDA.EventService.Services.Availability
{
    [KafkaTopicAttribute(AvailabilityEvent.AVAILABILITY_PROVIDER_FINISH)]
    public class AvaialbilityProviderOneFinishService: KafkaEdaBase, IKafkaEvent
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;


        public AvaialbilityProviderOneFinishService(IKafkaConfiguration configuration, IMediator mediator, IMapper mapper)
        : base(configuration)
        {
            this._mapper = mapper;
            this._mediator = mediator;
        }

        public async override Task Handler(ConsumeResult<Ignore, string> result)
         {
             var response = result.Message.Value.ToDeserializeJSON<AvailabilityOneResponse>();
             _mediator.Send(response);
         }
    }
}

