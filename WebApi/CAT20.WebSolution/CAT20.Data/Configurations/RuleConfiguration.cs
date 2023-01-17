using CAT20.Core.Models.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text;

namespace CAT20.Data.Configurations
{
    public class RuleConfiguration : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            #region Properties

            builder.HasKey(t => t.ID);
            builder.ToTable("Rules");

            builder.Property(t => t.Code).HasColumnName("Code").HasColumnType("nvarchar").HasMaxLength(20);
            builder.Property(t => t.Description).HasColumnName("Description").HasColumnType("nvarchar").HasMaxLength(200);

            builder.Property(t => t.User).HasColumnName("UserCreated").HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(t => t.TimeStamp).HasColumnName("TimeStamp").HasColumnType("Timestamp").IsConcurrencyToken(true).ValueGeneratedOnAdd();
            builder.Property(t => t.DateCreated).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(t => t.DateModified).HasColumnName("DateModified").HasColumnType("datetime");
            builder.Ignore(t => t.AuditReference);
            builder.Ignore(t => t.State);

            #endregion
        }
    }
}
