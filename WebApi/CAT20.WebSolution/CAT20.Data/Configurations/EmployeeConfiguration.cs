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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            #region Properties

            builder.HasKey(t => t.ID);
            builder.ToTable("Employees");

            builder.Property(t => t.Title).HasColumnName("Title").HasColumnType("int").IsRequired(false);
            builder.Property(t => t.Code).HasColumnName("Code").HasColumnType("nvarchar").HasMaxLength(20);
            builder.Property(t => t.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(t => t.LastName).HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(t => t.Phone).HasColumnName("Phone").HasColumnType("nvarchar").HasMaxLength(20);
            builder.Property(t => t.Designation).HasColumnName("Designation").HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(t => t.Extension).HasColumnName("Extension").HasColumnType("nvarchar").HasMaxLength(20);
            builder.Property(t => t.Mobile).HasColumnName("Mobile").HasColumnType("nvarchar").HasMaxLength(20);
            builder.Property(t => t.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(t => t.UserName).HasColumnName("UserName").HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(t => t.Password).HasColumnName("Password").HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(t => t.IsActive).HasColumnName("IsActive").HasColumnType("bit");
            builder.Property(t => t.SignatureFileName).HasColumnName("SignatureFileName").HasColumnType("nvarchar").HasMaxLength(200);

            builder.Property(t => t.User).HasColumnName("UserCreated").HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(t => t.TimeStamp).HasColumnName("TimeStamp").HasColumnType("Timestamp").IsConcurrencyToken(true).ValueGeneratedOnAdd();
            builder.Property(t => t.DateCreated).HasColumnName("DateCreated").HasColumnType("datetime");
            builder.Property(t => t.DateModified).HasColumnName("DateModified").HasColumnType("datetime");
            builder.Ignore(t => t.State);
            builder.Ignore(t => t.AuditReference);

            #endregion

            #region Relations

            builder.HasMany(t => t.SabhaList).WithOne(l => l.Employee).HasForeignKey(t => t.EmployeeID).OnDelete(DeleteBehavior.ClientCascade);

            #endregion
        }
    }
}
