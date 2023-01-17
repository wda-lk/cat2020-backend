using CAT20.Core.Models.Control;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace CAT20.Data.Configurations
{
    public class AppCategoryConfiguration : IEntityTypeConfiguration<AppCategory>
    {
        public void Configure(EntityTypeBuilder<AppCategory> builder)
        {
            builder
                .HasKey(a => a.ID).HasName("PRIMARY");

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(250)
                .IsRequired();

            builder
               .Property(m => m.Status);
        }
    }
}
