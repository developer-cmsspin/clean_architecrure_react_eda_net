using System;
using ArchitectureEDA.Domain.Model.AvaialbilityTwo;
using ArchitectureEDA.Domain.Model.AvailabilityOne;

namespace ArchitectureEDA.Domain.Interfaces.Infrastructure.Availability
{
    public interface IProviderTwoInfrastructure
    {
        Task<AvailabilityTwoResponse> Execute(AvailabilityTwoRequest request);
    }
}

