using System;
using AutoMapper;
using MediatR;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Interfaces.Infrastructure.Availability;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Model.AvailabilityOne;
using ArchitectureEDA.Domain.Model.State.Avaialbility;
using ArchitectureEDA.Domain.Model.State.Availability;

namespace ArchitectureEDA.Application.Services.Availability;

public class AvailabilityProviderOneHandler : IRequestHandler<AvailabilityOneRequest>
{
    private readonly IKafka _kafka;
    private readonly IMapper _mapper;
    private readonly IProviderOneInfrastructure _providerOneInfrastructure;

    public AvailabilityProviderOneHandler(IKafka kafka, IProviderOneInfrastructure providerOneInfrastructure, IMapper mapper)
    {
        this._kafka = kafka;
        this._mapper = mapper;
        this._providerOneInfrastructure = providerOneInfrastructure;
    }

    public async Task<Unit> Handle(AvailabilityOneRequest request, CancellationToken cancellationToken)
    {

        this._kafka.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_START, new AvailabilityState(request.CorrelationId, "P1", AvaialbilityStatusType.Start));
        Thread.Sleep(2000);
        this._kafka.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_WAITING, new AvailabilityState(request.CorrelationId, "P1", AvaialbilityStatusType.Waiting));

        var response = await this._providerOneInfrastructure.Execute(request);
        var responseMessage = this._mapper.Map<AvailabilityResponse>(response);

        responseMessage.Provider = "P1";
        responseMessage.correlationId = request.CorrelationId;

        this._kafka.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_REPLY, responseMessage);
        this._kafka.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_FINISH, new AvailabilityState(request.CorrelationId, "P1", AvaialbilityStatusType.Finish));

        return Unit.Value;
    }
}

