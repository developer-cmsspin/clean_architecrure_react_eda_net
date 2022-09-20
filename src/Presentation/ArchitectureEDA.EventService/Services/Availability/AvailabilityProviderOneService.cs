using AutoMapper;
using Confluent.Kafka;
using MediatR;
using ArchitectureEDA.Application.Commons.Kafka.Commons;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Dto.Availability;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Model.AvailabilityOne;
using Spin.Helper.Extend;

namespace ArchitectureEDA.EventService.Services;

[KafkaTopicAttribute(AvailabilityEvent.AVAILABILITY_PROVIDER_SERVICE)]
public class AvailabilityProviderOneService: KafkaEdaBase, IKafkaEvent
{
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;

    public AvailabilityProviderOneService(IKafkaConfiguration configuration, IMediator mediator, IMapper mapper)
        : base(configuration)
    {
        this._mapper = mapper;
        this._mediator = mediator;
    }

    public override Task Handler(ConsumeResult<Ignore, string> result)
        => Task.Factory.StartNew(() =>
        {
            var request = result.Message.Value.ToDeserializeJSON<AvailabilityRequestDto>();
            _mediator.Send(_mapper.Map<AvailabilityOneRequest>(request));
        });
}

