using System;
using Microsoft.Extensions.Options;
using ArchitectureEDA.Domain.Entities.State;
using ArchitectureEDA.Domain.Model.State.Availability;
using ArchitectureEDA.Infrastructure.Persistence.Configuration;
using MongoDB.Driver;
using Schema.NET;

namespace ArchitectureEDA.Infrastructure.Persistence.Context;

public class StateContext
{
    public readonly IMongoCollection<FlowState> Flowstate;

    public StateContext(IOptions<StateDatabaseSettings> stateDatabaseSettings)
    {
        var mongoClient = new MongoClient(stateDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(stateDatabaseSettings.Value.DatabaseName);
        Flowstate = mongoDatabase.GetCollection<FlowState>(stateDatabaseSettings.Value.BooksCollectionName);
    }
}

