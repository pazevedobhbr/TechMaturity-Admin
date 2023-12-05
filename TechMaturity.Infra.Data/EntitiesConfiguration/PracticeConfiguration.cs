using System;
using TechMaturity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechMaturity.Infra.Data.EntitiesConfiguration
{
    public class PracticeConfiguration :IEntityTypeConfiguration<Practice>
    {
        public void Configure(EntityTypeBuilder< Practice> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new  Practice(1, "DevSecOps"),
                new  Practice(2, "Architecture")
            );
        }

        
    }
}

