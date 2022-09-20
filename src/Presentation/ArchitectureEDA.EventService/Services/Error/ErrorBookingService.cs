using System;
using AutoMapper;
using Confluent.Kafka;
using MediatR;
using ArchitectureEDA.Application.Commons.Kafka.Commons;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Dto.Availability;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Models.Error;
using Spin.Helper.Extend;

namespace ArchitectureEDA.EventService.Services.Error
{
    [KafkaTopicAttribute(AvailabilityEvent.AVAILABILITY_ERROR)]
    public class ErrorBookingService: KafkaEdaBase, IKafkaEvent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ErrorBookingService(IKafkaConfiguration configuration, IMediator mediator, IMapper mapper)
            : base(configuration)
        {
            this._mapper = mapper;
            this._mediator = mediator;
        }

        public async override Task Handler(ConsumeResult<Ignore, string> result)
        {
            try
            {
                var request = result.Message.Value.ToDeserializeJSON<ErrorRequest>();
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

