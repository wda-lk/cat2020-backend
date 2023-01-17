using CAT20.Core.Models.Control;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace CAT20.Data.Configurations
{
    public class YearConfiguration : IEntityTypeConfiguration<Year>
    {
        public void Configure(EntityTypeBuilder<Year> builder)
        {
            builder
                .HasKey(a => a.ID).HasName("PRIMARY");

            builder
                .Property(m => m.Description)
                .IsRequired();
        }
    }
}
