using CAT20.Core.Models.Control;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace CAT20.Data.Configurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder
                .HasKey(a => a.ID).HasName("PRIMARY");

            builder
               .Property(m => m.ProvinceID)
               .IsRequired();

            builder
                .Property(m => m.NameSinhala)
                .IsRequired()
                .HasMaxLength(250);

            builder
               .Property(m => m.NameEnglish)
               .IsRequired()
               .HasMaxLength(250);

            builder
               .Property(m => m.NameTamil)
               .IsRequired()
               .HasMaxLength(250);

            builder
               .Property(m => m.Status)
               .IsRequired();
        }
    }
}
