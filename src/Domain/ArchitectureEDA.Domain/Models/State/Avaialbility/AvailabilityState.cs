using System;
using MediatR;
using ArchitectureEDA.Domain.Model.State.Avaialbility;

namespace ArchitectureEDA.Domain.Model.State.Availability
{
    public class AvailabilityState: IRequest<Unit>
    {
        public AvailabilityState()
        {

        }

        public AvailabilityState(string correlationId, string providerName, AvaialbilityStatusType status)
        {
            this.CorrelationId = correlationId;
            this.State = status;
            this.ProviderName = providerName;
        }

        public string CorrelationId { get; set; }
        public string ProviderName { get; set; }
        public AvaialbilityStatusType State { get; set; }
        public string Step { get => "Availability"; }
    }
}

