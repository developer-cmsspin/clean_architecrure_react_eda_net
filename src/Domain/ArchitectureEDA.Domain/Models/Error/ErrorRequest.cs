using System;
using MediatR;

namespace ArchitectureEDA.Domain.Models.Error
{
    public class ErrorRequest : IRequest<Unit>
    {
        public string Step { get; set; }
        public string ExceptionName { get; set; }
    }
}

