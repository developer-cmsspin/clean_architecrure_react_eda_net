using System;
using AutoMapper;
using Confluent.Kafka;
using MediatR;
using ArchitectureEDA.Application.Commons.Kafka.Commons;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Models;
using ArchitectureEDA.Domain.Models.Error;
using Spin.Helper.Extend;

namespace ArchitectureEDA.EventService.Services.Session
{
    [KafkaTopicAttribute(AvailabilityEvent.AVAILABILITY_REPLY)]
    [KafkaTopicAttribute(AvailabilityEvent.AVAILABILITY_PROVIDER_REPLY)]
    public class SessionBookingService: KafkaEdaBase, IKafkaEvent
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public SessionBookingService(IKafkaConfiguration configuration, IMediator mediator, IMapper mapper)
        : base(configuration)
        {
            this._mapper = mapper;
            this._mediator = mediator;
        }

        public async override Task Handler(ConsumeResult<Ignore, string> result)
        {
            try
            {
                if(result.Topic == AvailabilityEvent.AVAILABILITY_PROVIDER_REPLY){
                    var request = result.Message.Value.ToDeserializeJSON<AvailabilityResponse>();
                    await _mediator.Send(new SessionRequest() {
                        Provider = request.Provider,
                        response = request,
                        CorrelationId = request.correlationId
                    });
                }

                if(result.Topic == AvailabilityEvent.AVAILABILITY_REPLY){
                    var request = result.Message.Value.ToDeserializeJSON<AvailabilityResponse>();
                    await _mediator.Send(new SessionRequest()
                    {
                        response = request
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

