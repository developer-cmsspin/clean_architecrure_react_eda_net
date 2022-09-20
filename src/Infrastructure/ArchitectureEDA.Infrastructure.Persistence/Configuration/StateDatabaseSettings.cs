using System;
namespace ArchitectureEDA.Infrastructure.Persistence.Configuration
{
    public class StateDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BooksCollectionName { get; set; } = null!;
    }
}

