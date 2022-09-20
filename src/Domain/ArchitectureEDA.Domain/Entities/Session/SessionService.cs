using System;
using ArchitectureEDA.Domain.Model.Availability;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArchitectureEDA.Domain.Entities.Session
{
    public class SessionService
    {
        public SessionService()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Provider { get; set; }

        public string CorrelationId { get; set; }

        public AvailabilityRequest  request{ get; set; }

        public AvailabilityResponse response { get; set; }
    }
}

