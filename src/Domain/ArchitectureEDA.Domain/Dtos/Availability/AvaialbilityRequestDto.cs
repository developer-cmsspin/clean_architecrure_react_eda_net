using System;
using MediatR;

namespace ArchitectureEDA.Domain.Dto.Availability;

/// <summary>
/// Availability Request
/// </summary>
public record class AvailabilityRequestDto 
{
    public string CorrelationId { get; set; }
    public int Pickup { get; set; }
    public int Return { get; set; }
}

