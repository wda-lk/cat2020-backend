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
    public class AuditTrailDetailConfiguration : IEntityTypeConfiguration<AuditTrailDetail>
    {
        public void Configure(EntityTypeBuilder<AuditTrailDetail> builder)
        {
            #region Properties

            builder.HasKey(t => t.ID);
            builder.ToTable("AuditTrailDetails");

            builder.Property(t => t.AuditTrailID).HasColumnName("AuditTrailID").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.EntityType).HasColumnName("EntityType").HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(t => t.EntityID).HasColumnName("EntityID").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.Property).HasColumnName("Property").HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(t => t.PreviousValue).HasColumnName("PreviousValue").HasColumnType("nvarchar").HasMaxLength(500);
            builder.Property(t => t.NewValue).HasColumnName("NewValue").HasColumnType("nvarchar").HasMaxLength(500);
            builder.Property(t => t.Action).HasColumnName("Action").HasColumnType("int").IsRequired(false);

            builder.Property(t => t.User).HasColumnName("UserCreated").HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(t => t.TimeStamp).HasColumnName("TimeStamp").HasColumnType("Timestamp").IsConcurrencyToken(true).ValueGeneratedOnAdd();
            builder.Property(t => t.DateCreated).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(t => t.DateModified).HasColumnName("DateModified").HasColumnType("datetime");
            builder.Ignore(t => t.AuditReference);
            builder.Ignore(t => t.State);

            #endregion

            #region Relations


            #endregion
        }
    }
}
