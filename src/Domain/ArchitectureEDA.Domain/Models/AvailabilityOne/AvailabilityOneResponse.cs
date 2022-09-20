using System;
using MediatR;

namespace ArchitectureEDA.Domain.Model.AvailabilityOne
{
    public class AvailabilityOneResponse: IRequest<Unit>
    {
        public AvailabilityOneResponse()
        {
        }
        public List<string> Data { get; set; }
    }
}

