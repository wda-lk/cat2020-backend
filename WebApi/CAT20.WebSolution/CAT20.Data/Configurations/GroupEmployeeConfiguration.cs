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
    public class GroupEmployeeConfiguration : IEntityTypeConfiguration<GroupEmployee>
    {
        public void Configure(EntityTypeBuilder<GroupEmployee> builder)
        {
            #region Properties

            builder.HasKey(t => t.ID);
            builder.ToTable("GroupEmployees");

            builder.Property(t => t.GroupID).HasColumnName("GroupID").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.EmployeeID).HasColumnName("EmployeeID").HasColumnType("int").IsRequired(false);

            builder.Property(t => t.User).HasColumnName("UserCreated").HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(t => t.TimeStamp).HasColumnName("TimeStamp").HasColumnType("Timestamp").IsConcurrencyToken(true).ValueGeneratedOnAdd();
            builder.Property(t => t.DateCreated).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(t => t.DateModified).HasColumnName("DateModified").HasColumnType("datetime");
            builder.Ignore(t => t.AuditReference);
            builder.Ignore(t => t.State);

            #endregion

            #region Relations

            builder.HasOne(t => t.Group).WithMany().HasForeignKey(t => t.GroupID).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(t => t.Employee).WithMany().HasForeignKey(t => t.EmployeeID).OnDelete(DeleteBehavior.ClientCascade);

            #endregion
        }
    }
}
