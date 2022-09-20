using System;
using AutoMapper;
using MediatR;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Interfaces.Infrastructure.Availability;
using ArchitectureEDA.Domain.Model.AvaialbilityTwo;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Model.AvailabilityOne;
using ArchitectureEDA.Domain.Model.State.Avaialbility;
using ArchitectureEDA.Domain.Model.State.Availability;

namespace ArchitectureEDA.Application.Services.Availability
{
    public class AvailabilityProviderTwoHandler : IRequestHandler<AvailabilityTwoRequest>
    {
        private readonly IKafka _kafka;
        private readonly IMapper _mapper;
        private readonly IProviderTwoInfrastructure _providerTwoInfrastructure;

        public AvailabilityProviderTwoHandler(IKafka kafka, IProviderTwoInfrastructure providerTwoInfrastructure, IMapper mapper)
        {
            this._kafka = kafka;
            this._mapper = mapper;
            this._providerTwoInfrastructure = providerTwoInfrastructure;
        }

        public async Task<Unit> Handle(AvailabilityTwoRequest request, CancellationToken cancellationToken)
        {

            this._kafka.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_START, new AvailabilityState(request.CorrelationId, "P2", AvaialbilityStatusType.Start));
            Thread.Sleep(2000);
            this._kafka.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_WAITING, new AvailabilityState(request.CorrelationId, "P2", AvaialbilityStatusType.Waiting));

            var response = await this._providerTwoInfrastructure.Execute(request);
            var responseMessage = this._mapper.Map<AvailabilityResponse>(response);

            responseMessage.Provider = "P2";
            responseMessage.correlationId = request.CorrelationId;

            Thread.Sleep(4000);

            this._kafka.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_REPLY, responseMessage);
            this._kafka.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_FINISH, new AvailabilityState(request.CorrelationId, "P2", AvaialbilityStatusType.Finish));

            return Unit.Value;
        }
    }
}

