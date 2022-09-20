using System;
using Microsoft.Extensions.Options;
using ArchitectureEDA.Domain.Entities.Error;
using ArchitectureEDA.Domain.Entities.State;
using ArchitectureEDA.Infrastructure.Persistence.Configuration;
using MongoDB.Driver;

namespace ArchitectureEDA.Infrastructure.Persistence.Context
{
    public class ErrorContext
    {
        public readonly IMongoCollection<ErrorService> Errors;

        public ErrorContext(IOptions<ErrorDatabaseSettings> stateDatabaseSettings)
        {
            var mongoClient = new MongoClient(stateDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(stateDatabaseSettings.Value.DatabaseName);
            Errors = mongoDatabase.GetCollection<ErrorService>(stateDatabaseSettings.Value.BooksCollectionName);
        }
    }
}

