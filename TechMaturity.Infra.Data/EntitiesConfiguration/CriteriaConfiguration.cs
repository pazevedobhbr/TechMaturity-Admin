using System;
using TechMaturity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechMaturity.Infra.Data.EntitiesConfiguration
{
    public class CriteriaConfiguration :IEntityTypeConfiguration<Criteria>
    {
        public void Configure(EntityTypeBuilder<Criteria> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();


            builder.HasOne(e => e.Capability).WithMany(e => e.Criterias).HasForeignKey(e => e.CapabilityID);
          

        }


    }
}


