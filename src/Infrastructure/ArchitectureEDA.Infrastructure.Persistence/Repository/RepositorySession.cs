using System;
using Confluent.Kafka;
using ArchitectureEDA.Domain.Entities.Error;
using ArchitectureEDA.Domain.Entities.Session;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Infrastructure.Persistence.Context;
using MongoDB.Driver;

namespace ArchitectureEDA.Infrastructure.Persistence.Repository
{
    public class RepositorySession: IRepositorySession
    {
        private readonly SessionContext _context;

        public RepositorySession(SessionContext context)
        {
            this._context = context;
        }

        public Task<List<SessionService>> GetByCorrelationId(string correlationId)
         => this._context.Sessions.Find(a => a.CorrelationId == correlationId).ToListAsync();


        public async Task SaveAsync(SessionService request)
         => await this._context.Sessions.InsertOneAsync(request);
    }
}