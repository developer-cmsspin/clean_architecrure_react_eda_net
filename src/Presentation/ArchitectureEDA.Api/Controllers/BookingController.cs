using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Dto.Availability;
using ArchitectureEDA.Domain.Event;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArchitectureEDA.Api.Controllers;

[Route("api/[controller]")]
public class BookingController : Controller
{
    private readonly IKafka _kafkaEda;

    public BookingController(IKafka kafkaEda)
    {
        this._kafkaEda = kafkaEda;
    }

    [HttpPost("Availability")]
    public async Task<AvaialbilityResponseDto> Availability([FromBody] AvailabilityRequestDto request)
    {
        await this._kafkaEda.Send(AvailabilityEvent.AVAILABILITY_SERVICE, request);
        return new AvaialbilityResponseDto();
    }
}

