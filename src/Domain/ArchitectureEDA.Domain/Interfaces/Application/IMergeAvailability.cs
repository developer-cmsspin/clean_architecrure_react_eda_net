using System;
using ArchitectureEDA.Domain.Entities.Session;

namespace ArchitectureEDA.Domain.Interfaces.Application
{
    public interface IMergeAvailability
    {
        SessionService Merge(List<SessionService> responses);
    }
}

