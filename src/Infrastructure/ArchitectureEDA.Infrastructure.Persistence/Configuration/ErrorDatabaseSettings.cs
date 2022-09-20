using System;
namespace ArchitectureEDA.Infrastructure.Persistence.Configuration
{
    public class ErrorDatabaseSettings
    {
            public string ConnectionString { get; set; } = null!;

            public string DatabaseName { get; set; } = null!;

            public string BooksCollectionName { get; set; } = null!;
    }
}

