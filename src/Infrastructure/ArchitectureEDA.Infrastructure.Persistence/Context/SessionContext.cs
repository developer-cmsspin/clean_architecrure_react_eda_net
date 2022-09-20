using System;
using Microsoft.Extensions.Options;
using ArchitectureEDA.Domain.Entities.Error;
using ArchitectureEDA.Domain.Entities.Session;
using ArchitectureEDA.Infrastructure.Persistence.Configuration;
using MongoDB.Driver;

namespace ArchitectureEDA.Infrastructure.Persistence.Context
{
    public class SessionContext
    {
        public readonly IMongoCollection<SessionService> Sessions;

        public SessionContext(IOptions<SessionDatabaseSettings> stateDatabaseSettings)
        {
            var mongoClient = new MongoClient(stateDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(stateDatabaseSettings.Value.DatabaseName);
            Sessions = mongoDatabase.GetCollection<SessionService>(stateDatabaseSettings.Value.BooksCollectionName);
        }
    }
}

