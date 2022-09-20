using System;
using MediatR;

namespace ArchitectureEDA.Domain.Model.Availability;

public class AvailabilityRequest : IRequest<Unit>
{
    public string CorrelationId { get; set; }
    public int Pickup { get; set; }
    public int Return { get; set; }
}

