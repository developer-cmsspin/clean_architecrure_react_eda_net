using System;
using AutoMapper;
using ArchitectureEDA.Domain.Entities.Error;
using ArchitectureEDA.Domain.Entities.Session;
using ArchitectureEDA.Domain.Models;
using ArchitectureEDA.Domain.Models.Error;

namespace ArchitectureEDA.Application.Configurations.Mappers
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<SessionRequest, SessionService>();
        }
    }
}

