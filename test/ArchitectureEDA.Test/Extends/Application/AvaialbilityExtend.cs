using System;
using Bogus;
using ArchitectureEDA.Domain.Entities.Session;
using ArchitectureEDA.Domain.Model.Availability;
using YamlDotNet.Core;

namespace ArchitectureEDA.Test.Extends.Application
{
    public static class AvaialbilityExtend
    {
        public static AvailabilityRequest CreateRequestAvaialbility(this Faker<AvailabilityRequest> faker)
        {

            faker.RuleFor(x => x.CorrelationId, f => f.Random.AlphaNumeric(15))
                .RuleFor(x => x.Pickup, f => f.Random.Int(1000))
                .RuleFor(x => x.Return, f => f.Random.Int(1000));

            var request = faker.Generate(1).FirstOrDefault();

            return request;
        }


        public static List<SessionService> CreateResponseAvaialbility(this Faker<List<SessionService>> faker, string correlationId)
        {
            Faker<SessionService> sessiionFaker = new();
            sessiionFaker.RuleFor(x => x.CorrelationId, f => correlationId)
                .RuleFor(x => x.response, f => new()
                {
                    correlationId = correlationId,
                    Provider = "P1",
                    Data = new() { f.Random.String2(2), f.Random.String2(2), f.Random.String2(2) }
                });

            return sessiionFaker.Generate(3).ToList();
        }
    }
}

