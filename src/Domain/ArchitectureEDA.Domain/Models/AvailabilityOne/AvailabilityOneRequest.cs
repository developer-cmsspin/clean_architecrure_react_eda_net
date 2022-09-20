using System;
using MediatR;

namespace ArchitectureEDA.Domain.Model.AvailabilityOne
{
    public class AvailabilityOneRequest: IRequest<Unit>
    {
        public AvailabilityOneRequest()
        {
        }

        public string CorrelationId { get; set; }
        public int Pickup { get; set; }
        public int Return { get; set; }
    }
}

