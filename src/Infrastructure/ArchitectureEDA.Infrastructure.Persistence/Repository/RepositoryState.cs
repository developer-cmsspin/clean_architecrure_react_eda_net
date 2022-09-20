using System;
using ArchitectureEDA.Domain.Entities.State;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Domain.Model.State.Avaialbility;
using ArchitectureEDA.Domain.Model.State.Availability;
using ArchitectureEDA.Infrastructure.Persistence.Context;
using MongoDB.Driver;

namespace ArchitectureEDA.Infrastructure.Persistence.Repository
{
    public class RepositoryState: IRepositoryState
    {
        private readonly StateContext _context;

        public RepositoryState(StateContext context)
        {
            this._context = context;
        }

        public Task<List<FlowState>> GetByStateAsync(AvaialbilityStatusType state, string correlationId)
            => _context.Flowstate.Find(a => a.CorrelationId == correlationId && a.State == state.ToString()).ToListAsync();

        public async Task<long> GetCountStateAsync(AvaialbilityStatusType state, string correlationId)
         => await _context.Flowstate.Find(a => a.CorrelationId == correlationId && a.State == state.ToString()).CountDocumentsAsync();

        public async Task SaveAsync(FlowState request)
            => await this._context.Flowstate.InsertOneAsync(request); 
    }
}

