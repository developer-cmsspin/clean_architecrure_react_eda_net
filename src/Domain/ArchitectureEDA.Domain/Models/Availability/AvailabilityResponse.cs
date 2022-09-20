using System;
namespace ArchitectureEDA.Domain.Model.Availability
{
    public class AvailabilityResponse
    {
        public AvailabilityResponse()
        {
        }

        public string Provider { get; set; }

        public string correlationId { get; set; }

        public List<string> Data { get; set; }
    }
}

