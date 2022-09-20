using System;
using ArchitectureEDA.Domain.Interfaces.Infrastructure.Availability;
using ArchitectureEDA.Domain.Model.AvaialbilityTwo;
using ArchitectureEDA.Domain.Model.AvailabilityOne;

namespace ArchitectureEDA.Infrastructure.Availability
{
    public class ProviderTwoInfrastructure : IProviderTwoInfrastructure
    {
        public ProviderTwoInfrastructure()
        {
        }

        public Task<AvailabilityTwoResponse> Execute(AvailabilityTwoRequest request)
        => Task.Factory.StartNew<AvailabilityTwoResponse>(() =>
        {
            Thread.Sleep(2000);
            return new AvailabilityTwoResponse()
            {
                Data = new List<string>() { "a", "b", "c" }
            };
        });
    }
}

