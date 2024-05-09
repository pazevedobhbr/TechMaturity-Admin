using System;
using TechMaturity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechMaturity.Infra.Data.EntitiesConfiguration
{
    public class CapabilityConfiguration :IEntityTypeConfiguration<Capability>
    {
        public void Configure(EntityTypeBuilder<Capability> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();


            builder.HasOne(e => e.Pillar).WithMany(e => e.Capabilities).HasForeignKey(e => e.PillarID);
          

        }


    }
}


