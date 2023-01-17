using CAT20.Core.Models.Control;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using Microsoft.Extensions.Logging;
using CAT20.Core.Models.Common;


namespace CAT20.Data
{
    public partial class ControlDbContext : DbContext
    {
        public ControlDbContext()
        {
        }

        public ControlDbContext(DbContextOptions<ControlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppCategory> AppCategories { get; set; }
        public virtual DbSet<BankDetail> BankDetails { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<OfficeType> OfficeTypes { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Sabha> Sabhas { get; set; }
        public virtual DbSet<SelectedLanguage> SelectedLanguages { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        public virtual DbSet<EmailConfiguration> EmailConfigurations { get; set; }
        public virtual DbSet<EmailOutBox> EmailOutBoxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<AppCategory>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("cd_app_category");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("cd_app_cat_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("cd_app_cat_name");

                entity.Property(e => e.Status).HasColumnName("cd_app_cat_status");
            });

            modelBuilder.Entity<BankDetail>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("cd_bank_details");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("cd_bd_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("cd_bd_name");

                entity.Property(e => e.Status).HasColumnName("cd_bd_status");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("cd_district");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.ProvinceID, "fk_cd_d_cd_p_id");

                entity.Property(e => e.ID).HasColumnName("cd_d_id");

                entity.Property(e => e.ProvinceID).HasColumnName("cd_d_cd_p_id");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("cd_d_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("cd_d_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("cd_d_name_tamil");

                entity.Property(e => e.Status).HasColumnName("cd_d_status");

                entity.HasOne(d => d.province)
                    .WithMany(p => p.district)
                    .HasForeignKey(d => d.ProvinceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cd_d_cd_p_id");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("cd_gender");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("cd_gender_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("cd_gender");

                entity.Property(e => e.Status).HasColumnName("cd_status");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("cd_languages");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("cd_languages_id");

                entity.Property(e => e.Status).HasColumnName("cd_language_status");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("cd_languages_name");
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.ToTable("cd_month");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("cd_month_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("cd_month");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("cd_office");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.SabhaID, "fk_cd_o_cd_s_id");

                entity.HasIndex(e => e.OfficeTypeID, "fk_cd_o_office_type_id");

                entity.Property(e => e.ID).HasColumnName("cd_o_id");

                entity.Property(e => e.SabhaID).HasColumnName("cd_o_cd_s_id");

                entity.Property(e => e.CreatedDate).HasColumnName("cd_o_create_date");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("cd_o_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("cd_o_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("cd_o_name_tamil");

                entity.Property(e => e.OfficeTypeID).HasColumnName("cd_o_office_type_id");

                entity.Property(e => e.Status).HasColumnName("cd_o_status");

                entity.HasOne(d => d.sabha)
                    .WithMany(p => p.office)
                    .HasForeignKey(d => d.SabhaID)
                    .HasConstraintName("fk_cd_o_cd_s_id");

                entity.HasOne(d => d.officeType)
                    .WithMany(p => p.office)
                    .HasForeignKey(d => d.OfficeTypeID)
                    .HasConstraintName("fk_cd_o_office_type_id");
            });

            modelBuilder.Entity<OfficeType>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("cd_office_type");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("cd_ot_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("cd_ot_name");

                entity.Property(e => e.Status).HasColumnName("cd_ot_status");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("cd_province");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("cd_p_id");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("cd_p_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("cd_p_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("cd_p_name_tamil");

                entity.Property(e => e.Status).HasColumnName("cd_p_status");
            });

            modelBuilder.Entity<Sabha>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("cd_sabha");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.DistrictID, "fk_cd_s_cd_d_id");

                entity.Property(e => e.ID).HasColumnName("cd_s_id");

                entity.Property(e => e.AddressEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_address_english");

                entity.Property(e => e.AddressSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_address_sinhala");

                entity.Property(e => e.AddressTamil)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_address_tamil");

                entity.Property(e => e.DistrictID).HasColumnName("cd_s_cd_d_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_code");

                entity.Property(e => e.CreatedDate).HasColumnName("cd_s_create_date");

                entity.Property(e => e.LogoPath)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_logo_path");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_name_tamil");

                entity.Property(e => e.Status).HasColumnName("cd_s_status");

                entity.Property(e => e.Telephone1)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_tp_no1");

                entity.Property(e => e.Telephone2)
                    .HasMaxLength(255)
                    .HasColumnName("cd_s_tp_no2");

                entity.HasOne(d => d.district)
                    .WithMany(p => p.sabha)
                    .HasForeignKey(d => d.DistrictID)
                    .HasConstraintName("fk_cd_s_cd_d_id");
            });

            modelBuilder.Entity<SelectedLanguage>(entity =>
            {
                entity.ToTable("cd_selected_languages");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("cd_selected_languages_id");

                entity.Property(e => e.LanguageID).HasColumnName("cd_selected_languages_lang_id");

                entity.Property(e => e.SabhaID).HasColumnName("cd_selected_languages_sabha_id");

                entity.Property(e => e.Status).HasColumnName("cd_selected_languages_status");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.ToTable("cd_year");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("cd_year_id");

                entity.Property(e => e.Description).HasColumnName("cd_year");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("cdb_customer_types");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("cdb_cus_type_id");

                entity.Property(e => e.NameInEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("cdb_cus_type_name_in_english");

                entity.Property(e => e.NameInSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("cdb_cus_type_name_in_sinhala");

                entity.Property(e => e.NameInTamil)
                    .HasMaxLength(255)
                    .HasColumnName("cdb_cus_type_name_in_tamil");

                entity.Property(e => e.Status).HasColumnName("cdb_cus_type_status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}