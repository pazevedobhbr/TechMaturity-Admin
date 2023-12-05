using System;
using TechMaturity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechMaturity.Infra.Data.EntitiesConfiguration
{
    public class PillarConfiguration :IEntityTypeConfiguration<Pillar>
    {
        public void Configure(EntityTypeBuilder<Pillar> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Pillar(1, "Continuous Integration"),
                new Pillar(2, "Continuous Testing"),
                new Pillar(3, "Continuous Deployment"),
                new Pillar(4, "Continuous Monitoring"),
                new Pillar(5, "Secure by Design"),
                new Pillar(6, "Privacy by Design"),
                new Pillar(7, "Architecture Definition"),
                new Pillar(8, "Architecture Delivery"),
                new Pillar(9, "Architecture Management")
            );
        }

        
    }
}

