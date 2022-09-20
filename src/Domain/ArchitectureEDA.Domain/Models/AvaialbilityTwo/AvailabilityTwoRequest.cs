using System;
using MediatR;

namespace ArchitectureEDA.Domain.Model.AvaialbilityTwo
{
    public class AvailabilityTwoRequest: IRequest<Unit>
    {
        public AvailabilityTwoRequest()
        {
        }

        public string CorrelationId { get; set; }
        public int Pickup { get; set; }
        public int Return { get; set; }
    }
}

