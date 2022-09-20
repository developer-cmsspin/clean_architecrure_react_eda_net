using System;
using ArchitectureEDA.Domain.Entities.Error;

namespace ArchitectureEDA.Domain.Interfaces.Persistence.Repository
{
    public interface IRepositoryError
    {
        Task SaveAsync(ErrorService error);
    }
}

