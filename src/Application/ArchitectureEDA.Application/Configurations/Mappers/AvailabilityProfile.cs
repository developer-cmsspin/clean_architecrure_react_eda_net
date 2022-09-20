using System;
using AutoMapper;
using ArchitectureEDA.Domain.Dto.Availability;
using ArchitectureEDA.Domain.Model.AvaialbilityTwo;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Model.AvailabilityOne;

namespace ArchitectureEDA.Application.Configurations.Mappers
{
    public class AvailabilityProfile: Profile
    {
        public AvailabilityProfile()
        {
            CreateMap<AvailabilityRequestDto, AvailabilityRequest>();
            CreateMap<AvailabilityRequestDto, AvailabilityOneRequest>();
            CreateMap<AvailabilityRequestDto, AvailabilityTwoRequest>();
            CreateMap<AvailabilityOneResponse, AvailabilityResponse>();
            CreateMap<AvailabilityTwoResponse, AvailabilityResponse>();
        }
    }
}

