using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using TechMaturity.Domain.Entities;

namespace TechMaturity.Application.DTOs
{
    public class CriteriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [JsonIgnore]
        public Pillar? Pillar { get; set; }

        [DisplayName("Capabilities")]
        public int CapabilityID { get; set; }

    }
}


