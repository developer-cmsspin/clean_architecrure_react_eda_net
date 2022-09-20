using AutoMapper;
using Confluent.Kafka;
using MediatR;
using ArchitectureEDA.Application.Commons.Kafka.Commons;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Dto.Availability;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Model.State.Avaialbility;
using Spin.Helper.Extend;


namespace MAvailabilityRequestDto.Services;

[KafkaTopicAttribute(AvailabilityEvent.AVAILABILITY_SERVICE)]
public class AvailabilityService : KafkaEdaBase, IKafkaEvent
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public AvailabilityService(IKafkaConfiguration configuration, IMediator mediator, IMapper mapper)
        : base(configuration)
    {
        this._mapper = mapper;
        this._mediator = mediator;
    }

    public async override Task Handler(ConsumeResult<Ignore, string> result)
    {
        try
        {
            var request = result.Message.Value.ToDeserializeJSON<AvailabilityRequestDto>();
            var requestModel = _mapper.Map<AvailabilityRequest>(request);
            await _mediator.Send(requestModel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}