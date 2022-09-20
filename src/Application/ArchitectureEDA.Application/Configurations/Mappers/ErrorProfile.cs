using System;
using AutoMapper;
using ArchitectureEDA.Domain.Dto.Availability;
using ArchitectureEDA.Domain.Entities.Error;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Models.Error;

namespace ArchitectureEDA.Application.Configurations.Mappers
{
    public class ErrorProfile:Profile
    {
        public ErrorProfile()
        {
            CreateMap<ErrorRequest, ErrorService>();
        }
    }
}

