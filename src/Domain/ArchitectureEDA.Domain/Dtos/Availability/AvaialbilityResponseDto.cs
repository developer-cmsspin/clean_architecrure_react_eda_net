using System;
namespace ArchitectureEDA.Domain.Dto.Availability
{
    /// <summary>
    /// Avaialbility Response
    /// </summary>
    public record class AvaialbilityResponseDto
    {
        public List<string> Data { get; set; }
    }
    
}

