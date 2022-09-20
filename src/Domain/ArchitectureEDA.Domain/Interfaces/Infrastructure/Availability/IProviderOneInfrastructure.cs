using System;
using ArchitectureEDA.Domain.Model.AvailabilityOne;

namespace ArchitectureEDA.Domain.Interfaces.Infrastructure.Availability
{
    public interface IProviderOneInfrastructure
    {
        Task<AvailabilityOneResponse> Execute(AvailabilityOneRequest request);
    }
}

