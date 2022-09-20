using System;
using AutoMapper;
using Bogus;
using ArchitectureEDA.Application.Commons.Kafka;
using ArchitectureEDA.Application.Configurations.Mappers;
using ArchitectureEDA.Application.Services.Availability;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Entities.Session;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Model.State.Avaialbility;
using ArchitectureEDA.Test.Extends.Application;
using Moq;

namespace ArchitectureEDA.Test.Application.Services
{
    [TestFixture]
    public class AvailabilityHandlerTest
    {
        [OneTimeSetUp]
        public void Init()
        {

        }


        [Test]
        public void Application_Handler_Accept()
        {
            //mapper
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AvailabilityProfile()));
            IMapper mapper = new Mapper(configuration);



            AvailabilityRequest request = new Faker<AvailabilityRequest>().CreateRequestAvaialbility();
            List<SessionService> response = new Faker<List<SessionService>>().CreateResponseAvaialbility(request.CorrelationId);


            Mock <IKafka> mockKafka = new();
            mockKafka.Setup(x => x.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_SERVICE, request));
            mockKafka.Setup(x => x.Send(AvailabilityEvent.AVAILABILITY_REPLY, response));


            Mock<IRepositoryState> mockRepositoryState = new();
            mockRepositoryState.Setup(x => x.GetCountStateAsync(AvaialbilityStatusType.Start, request.CorrelationId))
                .Returns(Task.FromResult<long>(10));
            mockRepositoryState.Setup(x => x.GetCountStateAsync(AvaialbilityStatusType.Finish, request.CorrelationId))
                .Returns(Task.FromResult<long>(10));

            Mock<IRepositorySession> mockRepositorySession = new();
            mockRepositorySession.Setup(x => x.GetByCorrelationId(request.CorrelationId))
                .Returns(Task.FromResult(response));
            mockRepositorySession.Setup(x => x.GetByCorrelationId(request.CorrelationId))
                .Returns(Task.FromResult(response));


            AvailabilityHandler availability = new(mockKafka.Object, mockRepositoryState.Object, mockRepositorySession.Object);
            availability.Handle(request, new CancellationToken()).GetAwaiter().GetResult();
        }


        [Test]
        public void Application_Handler_Timeout()
        {
            //mapper
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AvailabilityProfile()));
            IMapper mapper = new Mapper(configuration);



            AvailabilityRequest request = new Faker<AvailabilityRequest>().CreateRequestAvaialbility();
            List<SessionService> response = new Faker<List<SessionService>>().CreateResponseAvaialbility(request.CorrelationId);


            Mock<IKafka> mockKafka = new();
            mockKafka.Setup(x => x.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_SERVICE, request));
            mockKafka.Setup(x => x.Send(AvailabilityEvent.AVAILABILITY_REPLY, response));


            Mock<IRepositoryState> mockRepositoryState = new();
            mockRepositoryState.Setup(x => x.GetCountStateAsync(AvaialbilityStatusType.Start, request.CorrelationId))
                .Returns(Task.FromResult<long>(10));
            mockRepositoryState.Setup(x => x.GetCountStateAsync(AvaialbilityStatusType.Finish, request.CorrelationId))
                .Returns(Task.FromResult<long>(5));

            Mock<IRepositorySession> mockRepositorySession = new();
            mockRepositorySession.Setup(x => x.GetByCorrelationId(request.CorrelationId))
                .Returns(Task.FromResult(response));
            mockRepositorySession.Setup(x => x.GetByCorrelationId(request.CorrelationId))
                .Returns(Task.FromResult(response));


            AvailabilityHandler availability = new(mockKafka.Object, mockRepositoryState.Object, mockRepositorySession.Object);
            availability.Handle(request, new CancellationToken()).GetAwaiter().GetResult();

            //validate with message

        }


    }
}

