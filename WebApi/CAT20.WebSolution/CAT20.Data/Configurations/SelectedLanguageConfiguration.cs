using CAT20.Core.Models.Control;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace CAT20.Data.Configurations
{
    public class SelectedLanguageConfiguration : IEntityTypeConfiguration<SelectedLanguage>
    {
        public void Configure(EntityTypeBuilder<SelectedLanguage> builder)
        {
            builder
                .HasKey(a => a.ID).HasName("PRIMARY");

            builder
                .Property(m => m.LanguageID)
                .IsRequired();

            builder
               .Property(m => m.SabhaID)
               .IsRequired();

            builder
               .Property(m => m.Status)
               .IsRequired();
        }
    }
}
