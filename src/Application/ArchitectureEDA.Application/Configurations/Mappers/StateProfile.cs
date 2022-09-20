using System;
using AutoMapper;
using ArchitectureEDA.Domain.Dto.Availability;
using ArchitectureEDA.Domain.Entities.State;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Model.State.Availability;

namespace ArchitectureEDA.Application.Configurations.Mappers
{
    public class StateProfile: Profile
    {
        public StateProfile()
        {
            CreateMap<AvailabilityState, FlowState>();
        }
    }
}

