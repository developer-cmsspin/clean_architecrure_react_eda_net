using System;
using MediatR;
using ArchitectureEDA.Domain.Model.Availability;

namespace ArchitectureEDA.Domain.Models
{
    public class SessionRequest: IRequest<Unit>
    {
        public SessionRequest()
        {
        }

        public string Provider { get; set; }

        public string CorrelationId { get; set; }

        public AvailabilityRequest request { get; set; }

        public AvailabilityResponse response { get; set; }
    }
}

