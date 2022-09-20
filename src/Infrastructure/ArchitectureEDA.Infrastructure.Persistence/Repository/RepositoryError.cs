using System;
using ArchitectureEDA.Domain.Entities.Error;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Infrastructure.Persistence.Context;

namespace ArchitectureEDA.Infrastructure.Persistence.Repository
{
    public class RepositoryError: IRepositoryError
    {
        private readonly ErrorContext _context;

        public RepositoryError(ErrorContext context)
        {
            this._context = context;
        }

        public async Task SaveAsync(ErrorService error)
         => await this._context.Errors.InsertOneAsync(error);
    }
}

