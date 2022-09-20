using System;
using AutoMapper;
using Confluent.Kafka;
using MAvailabilityRequestDto.Services;
using MediatR;
using ArchitectureEDA.Application.Configurations.Mappers;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Dto.Availability;
using ArchitectureEDA.Domain.Model.Availability;
using Moq;
using Spin.Helper.Extend;

namespace ArchitectureEDA.Test.Presentation.EventService
{
    [TestFixture]
    public class AvailabilityServiceTest
    {
        /// <summary>
        /// Start Unit test
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {

        }


        [Test]
        public void Availability_Handler_Message()
        {
            //mapper
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AvailabilityProfile()));
            IMapper mapper = new Mapper(configuration);

            //variable 
            var request = new AvailabilityRequestDto();
            var requestModel = mapper.Map<AvailabilityRequest>(request);
            var responseModel = new AvailabilityResponse();

            //mock mapper
            Mock <IMapper> mapperMock = new();
            mapperMock.Setup(x => x.Map<AvailabilityRequest>(request))
                .Returns(requestModel);

            //mediator
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(s => s.Send(requestModel, new CancellationToken()));



            //KafkaConfiguration
            var kafkaConfigurationMock = new Mock<IKafkaConfiguration>();


            //result mock
            var consumeResult = new Mock<ConsumeResult<Ignore, string>>().Object;
            consumeResult.Message = new() { Value = responseModel.ToSerializeJSON() };
            

            //call Service
            var Service = new AvailabilityService(kafkaConfigurationMock.Object, mediatorMock.Object, mapperMock.Object);
            var resultTask = Service.Handler(consumeResult);
            resultTask.GetAwaiter().GetResult();


        }


        
    }
}

