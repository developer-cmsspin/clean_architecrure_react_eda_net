using System;
using AutoMapper;
using MediatR;
using ArchitectureEDA.Domain.Entities.State;
using ArchitectureEDA.Domain.Interfaces.Infrastructure.Availability;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Domain.Model.State.Availability;

namespace ArchitectureEDA.Application.Services.State
{
    public class AvailabilitySessionHandler: IRequestHandler<AvailabilityState>
    {
        IRepositoryState _repositoryState;
        IMapper _mapper;

        public AvailabilitySessionHandler(IMapper mapper, IRepositoryState repositoryState)
        {
            this._repositoryState = repositoryState;
            this._mapper = mapper;
        }

        public Task<Unit> Handle(AvailabilityState request, CancellationToken cancellationToken)
        => Task.Factory.StartNew<Unit>(() =>
        {
            var state = this._mapper.Map<FlowState>(request);
            this._repositoryState.SaveAsync(state);
            return Unit.Value;
        });
    }
}

