using System;
using ArchitectureEDA.Domain.Interfaces.Infrastructure.Availability;
using ArchitectureEDA.Domain.Model.AvailabilityOne;

namespace ArchitectureEDA.Infrastructure.Availability
{
    public class ProviderOneInfrastructure : IProviderOneInfrastructure
    {
        public ProviderOneInfrastructure()
        {
        }

        public Task<AvailabilityOneResponse> Execute(AvailabilityOneRequest request)
         => Task.Factory.StartNew<AvailabilityOneResponse>(() =>
         {
             Thread.Sleep(6000);
             return new AvailabilityOneResponse()
             {
                 Data = new List<string>() { "A", "B", "C" }
             };
          });
    
    }
}

