using System;
using AutoMapper;
using MediatR;
using ArchitectureEDA.Domain.Entities.Error;
using ArchitectureEDA.Domain.Entities.State;
using ArchitectureEDA.Domain.Interfaces.Infrastructure.Availability;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Domain.Models.Error;

namespace ArchitectureEDA.Application.Services.Error
{
    public class ErrorHandler: IRequestHandler<ErrorRequest>
    {
        IRepositoryError _repositoryError;
        IMapper _mapper;

        public ErrorHandler(IMapper mapper, IRepositoryError repositoryError)
        {   
            this._repositoryError = repositoryError;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(ErrorRequest request, CancellationToken cancellationToken)
        {
            var error = this._mapper.Map<ErrorService>(request);
            this._repositoryError.SaveAsync(error);
            return Unit.Value;
        }
    }
}

