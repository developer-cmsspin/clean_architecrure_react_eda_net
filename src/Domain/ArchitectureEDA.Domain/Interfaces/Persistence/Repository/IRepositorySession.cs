using System;
using ArchitectureEDA.Domain.Entities.Session;
using ArchitectureEDA.Domain.Entities.State;

namespace ArchitectureEDA.Domain.Interfaces.Persistence.Repository
{
    public interface IRepositorySession
    {
        Task SaveAsync(SessionService request);
        Task<List<SessionService>> GetByCorrelationId(string correlationId);
    }
}

