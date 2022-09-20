using System;
using ArchitectureEDA.Domain.Model.State.Avaialbility;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArchitectureEDA.Domain.Entities.State
{
    public class FlowState
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string CorrelationId { get; set; }
        public string ProviderName { get; set; }
        public string State { get; set; }
        public string Step { get; set; }
    }
}

