using CAT20.Core.Models.Control;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace CAT20.Data.Configurations
{
    public class SabhaConfiguration : IEntityTypeConfiguration<Sabha>
    {
        public void Configure(EntityTypeBuilder<Sabha> builder)
        {
            builder
                .HasKey(a => a.ID).HasName("PRIMARY"); ;

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
               .Property(m => m.Code)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(m => m.LogoPath)
               .IsRequired()
               .HasMaxLength(250);

            builder
               .Property(m => m.Status)
               .IsRequired();

            builder
               .Property(m => m.CreatedDate);

            builder
               .Property(m => m.Telephone1);

            builder
               .Property(m => m.Telephone2);

            builder
                .Property(m => m.AddressSinhala)
                .IsRequired()
                .HasMaxLength(250);

            builder
               .Property(m => m.AddressEnglish)
               .IsRequired()
               .HasMaxLength(250);

            builder
               .Property(m => m.AddressTamil)
               .IsRequired()
               .HasMaxLength(250);
        }
    }
}
