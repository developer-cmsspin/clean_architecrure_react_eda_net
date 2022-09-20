using System;
using MediatR;

namespace ArchitectureEDA.Domain.Entities.Error
{
    public class ErrorService: IRequest<Unit>
    {
        public ErrorService()
        {
        }

        public string Step { get; set; }
        public string ExceptionName { get; set; }
    }
}

