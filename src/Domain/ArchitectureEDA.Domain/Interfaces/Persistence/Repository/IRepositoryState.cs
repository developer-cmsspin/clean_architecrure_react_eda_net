using System;
using ArchitectureEDA.Domain.Entities.State;
using ArchitectureEDA.Domain.Model.State.Avaialbility;
using ArchitectureEDA.Domain.Model.State.Availability;

namespace ArchitectureEDA.Domain.Interfaces.Persistence.Repository;

public interface IRepositoryState
{
    Task SaveAsync(FlowState request);
    Task<List<FlowState>> GetByStateAsync(AvaialbilityStatusType state, string correlationId);
    Task<long> GetCountStateAsync(AvaialbilityStatusType state, string correlationId);
}

