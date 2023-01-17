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
    public class AuditTrailConfiguration : IEntityTypeConfiguration<AuditTrail>
    {
        public void Configure(EntityTypeBuilder<AuditTrail> builder)
        {
            #region Properties

            builder.HasKey(t => t.ID);
            builder.ToTable("AuditTrails");

            builder.Property(t => t.EntityType).HasColumnName("EntityType").HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(t => t.EntityID).HasColumnName("EntityID").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.EmployeeID).HasColumnName("EmployeeID").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.Date).HasColumnName("Date").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.Action).HasColumnName("Action").HasColumnType("int").IsRequired(false);

            builder.Property(t => t.User).HasColumnName("UserCreated").HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(t => t.TimeStamp).HasColumnName("TimeStamp").HasColumnType("Timestamp").IsConcurrencyToken(true).ValueGeneratedOnAdd();
            builder.Property(t => t.DateCreated).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(t => t.DateModified).HasColumnName("DateModified").HasColumnType("datetime");
            builder.Ignore(t => t.AuditReference);
            builder.Ignore(t => t.State);

            #endregion

            #region Relations

            builder.HasMany(t => t.DetailList).WithOne(l => l.AuditTrail).HasForeignKey(t => t.AuditTrailID).OnDelete(DeleteBehavior.ClientCascade);

            #endregion
        }
    }
}
