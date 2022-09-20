using System;
using AutoMapper;
using MediatR;
using ArchitectureEDA.Domain.Entities.Error;
using ArchitectureEDA.Domain.Entities.Session;
using ArchitectureEDA.Domain.Entities.State;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Models;
using ArchitectureEDA.Domain.Models.Error;

namespace ArchitectureEDA.Application.Services.Session
{
    public class SessionHandler : IRequestHandler<SessionRequest>
    {
        private readonly IRepositorySession _repository;
        private readonly IMapper _mapper;

        public SessionHandler(IRepositorySession repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(SessionRequest request, CancellationToken cancellationToken)
        {
            var session = this._mapper.Map<SessionService>(request);
            this._repository.SaveAsync(session);
            return Unit.Value;
        }
    }
}

