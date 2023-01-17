using CAT20.Core.Models.Vote;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using Microsoft.Extensions.Logging;


namespace CAT20.Data
{
    public partial class VoteAccDbContext : DbContext
    {
        public VoteAccDbContext()
        {
        }

        public VoteAccDbContext(DbContextOptions<VoteAccDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountBalanceDetail> AccountBalanceDetails { get; set; }
        public virtual DbSet<AccountDetail> AccountDetails { get; set; }
        public virtual DbSet<BalancesheetBalance> BalancesheetBalances { get; set; }
        public virtual DbSet<BalancesheetSubtitle> BalancesheetSubtitles { get; set; }
        public virtual DbSet<BalancesheetTitle> BalancesheetTitles { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<SubProject> SubProjects { get; set; }
        public virtual DbSet<IncomeSubtitle> IncomeSubtitles { get; set; }
        public virtual DbSet<IncomeTitle> IncomeTitles { get; set; }
        public virtual DbSet<VoteAllocation> VoteAllocations { get; set; }
        public virtual DbSet<Programme> Programmes { get; set; }
        public virtual DbSet<VoteDetail> VoteDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<AccountBalanceDetail>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("account_bal_details");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.AccountDetailID, "fk_acc_bd_acc_d_id");

                entity.Property(e => e.ID).HasColumnName("acc_bd_id");

                entity.Property(e => e.AccountDetailID).HasColumnName("acc_bd_acc_d_id");

                entity.Property(e => e.BalanceAmount).HasColumnName("acc_bd_bal_amount");

                entity.Property(e => e.EnteredDate).HasColumnName("acc_bd_enter_date");

                entity.Property(e => e.Status).HasColumnName("acc_bd_status");

                entity.Property(e => e.Year).HasColumnName("acc_bd_year");

                entity.Property(e => e.SabhaID).HasColumnName("acc_sabha_id");

                entity.HasOne(d => d.accountDetail)
                    .WithMany(p => p.accountBalDetail)
                    .HasForeignKey(d => d.AccountDetailID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acc_bd_acc_d_id");
            });

            modelBuilder.Entity<AccountDetail>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("account_details");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("acc_d_id");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(255)
                    .HasColumnName("acc_d_acc_no");

                entity.Property(e => e.BankID)
                    .HasColumnName("acc_d_bank_id")
                    .HasComment("control db fk");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("acc_d_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("acc_d_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("acc_d_name_tamil");

                entity.Property(e => e.OfficeID).HasColumnName("acc_d_office_id");

                entity.Property(e => e.Status).HasColumnName("acc_d_status");
            });

            modelBuilder.Entity<BalancesheetBalance>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("vt_balancesheet_balance");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("vt_balancesheet_bal_id");

                entity.Property(e => e.Balance).HasColumnName("vt_balancesheet_bal_balance");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .HasColumnName("vt_balancesheet_bal_comment");

                entity.Property(e => e.EnteredDate).HasColumnName("vt_balancesheet_bal_enter_date");

                entity.Property(e => e.SabhaID).HasColumnName("vt_balancesheet_bal_sabha_id");

                entity.Property(e => e.Status).HasColumnName("vt_balancesheet_bal_status");

                entity.Property(e => e.VoteDetailID).HasColumnName("vt_balancesheet_bal_vote_id");

                entity.Property(e => e.Year).HasColumnName("vt_balancesheet_bal_year");
            });

            modelBuilder.Entity<BalancesheetSubtitle>(entity =>
            {
                entity.ToTable("vt_balsheet_subtitle");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.BalsheetTitleID, "fk_vt_balsheet_subtitle_title_id");

                entity.Property(e => e.ID).HasColumnName("vt_balsheet_subtitle_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("vt_balsheet_subtitle_code");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_balsheet_subtitle_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_balsheet_subtitle_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_balsheet_subtitle_name_tamil");

                entity.Property(e => e.SabhaID).HasColumnName("vt_balsheet_subtitle_sabha_id");

                entity.Property(e => e.Status).HasColumnName("vt_balsheet_subtitle_status");
                //entity.Property(e => e.Status)
                //    .HasMaxLength(255)
                //    .HasColumnName("vt_balsheet_subtitle_status");

                entity.Property(e => e.BalsheetTitleID).HasColumnName("vt_balsheet_subtitle_title_id");

                entity.HasOne(d => d.balancesheetTitle)
                    .WithMany(p => p.balancesheetSubtitle)
                    .HasForeignKey(d => d.BalsheetTitleID)
                    .HasConstraintName("fk_vt_balsheet_subtitle_title_id");
            });

            modelBuilder.Entity<BalancesheetTitle>(entity =>
            {
                entity.ToTable("vt_balsheet_title");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("vt_balsheet_title_id");

                entity.Property(e => e.Balpath).HasColumnName("vt_balsheet_title_balpath");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("vt_balsheet_title_code");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_balsheet_title_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_balsheet_title_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_balsheet_title_name_tamil");

                entity.Property(e => e.SabhaID).HasColumnName("vt_balsheet_title_sabha_id");

                entity.Property(e => e.Status).HasColumnName("vt_balsheet_title_status");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("vt_inc_project");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.ProgrammeID, "fk_vt_inc_project_programme_id");

                entity.Property(e => e.ID).HasColumnName("vt_inc_project_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_project_code");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_project_english");

                entity.Property(e => e.ProgrammeID).HasColumnName("vt_inc_project_programme_id");

                entity.Property(e => e.SabhaID).HasColumnName("vt_inc_project_sabha_id");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_project_sinhala");

                entity.Property(e => e.Status).HasColumnName("vt_inc_project_status");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_project_tamil");

                entity.HasOne(d => d.programme)
                    .WithMany(p => p.project)
                    .HasForeignKey(d => d.ProgrammeID)
                    .HasConstraintName("fk_vt_inc_project_programme_id");
            });

            modelBuilder.Entity<SubProject>(entity =>
            {
                entity.ToTable("vt_inc_sub_project");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.ProjectID, "fk_vt_inc_sub_project_project_id");

                entity.Property(e => e.ID).HasColumnName("vt_inc_sub_project_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_sub_project_name_code");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_sub_project_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_sub_project_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_sub_project_name_tamil");

                entity.Property(e => e.ProjectID).HasColumnName("vt_inc_sub_project_project_id");

                entity.Property(e => e.SabhaID).HasColumnName("vt_inc_sub_project_sabha_id");
                entity.Property(e => e.ProgrammeID).HasColumnName("vt_inc_sub_project_programme_id");

                entity.Property(e => e.Status).HasColumnName("vt_inc_sub_project_status");

                entity.HasOne(d => d.project)
                    .WithMany(p => p.subProject)
                    .HasForeignKey(d => d.ProjectID)
                    .HasConstraintName("fk_vt_inc_sub_project_project_id");
            });

            modelBuilder.Entity<IncomeSubtitle>(entity =>
            {
                entity.ToTable("vt_inc_subtitle");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.IncomeTitleID, "fk_vt_inc_subtitle_title_id");

                entity.Property(e => e.ID).HasColumnName("vt_inc_subtitle_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_subtitle_name_code");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_subtitle_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_subtitle_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_subtitle_name_tamil");

                entity.Property(e => e.SabhaID).HasColumnName("vt_inc_subtitle_sabha_id");
                entity.Property(e => e.ProgrammeID).HasColumnName("vt_inc_subtitle_programme_id");

                entity.Property(e => e.Status).HasColumnName("vt_inc_subtitle_status");

                entity.Property(e => e.IncomeTitleID).HasColumnName("vt_inc_subtitle_title_id");

                entity.HasOne(d => d.incomeTitle)
                    .WithMany(p => p.incomeSubtitle)
                    .HasForeignKey(d => d.IncomeTitleID)
                    .HasConstraintName("fk_vt_inc_subtitle_title_id");
            });

            modelBuilder.Entity<IncomeTitle>(entity =>
            {
                entity.ToTable("vt_inc_title");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasIndex(e => e.ProgrammeID, "fk_vt_inc_title_name_programme_id");

                entity.Property(e => e.ID).HasColumnName("vt_inc_title_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_title_name_code");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_title_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_title_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_inc_title_name_tamil");

                entity.Property(e => e.ProgrammeID).HasColumnName("vt_inc_title_programme_id");

                entity.Property(e => e.SabhaID).HasColumnName("vt_inc_title_sabha_id");

                entity.Property(e => e.Status).HasColumnName("vt_inc_title_status");

                entity.HasOne(d => d.programme)
                    .WithMany(p => p.incomeTitle)
                    .HasForeignKey(d => d.ProgrammeID)
                    .HasConstraintName("fk_vt_inc_title_name_programme_id");
            });

            modelBuilder.Entity<VoteAllocation>(entity =>
            {
                entity.ToTable("vt_inc_vote_allocation");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("vt_inc_vote_allocation_id");

                entity.Property(e => e.AllocationAmount).HasColumnName("vt_inc_vote_allocation_allocation_amount");

                entity.Property(e => e.CreatedDate).HasColumnName("vt_inc_vote_allocation_create_date");

                entity.Property(e => e.IncomeAmount).HasColumnName("vt_inc_vote_allocation_inc_amount");

                entity.Property(e => e.SabhaID).HasColumnName("vt_inc_vote_allocation_sabha_id");

                entity.Property(e => e.Status).HasColumnName("vt_inc_vote_allocation_status");

                entity.Property(e => e.VoteDetailID).HasColumnName("vt_inc_vote_allocation_vote_id");

                entity.Property(e => e.Year).HasColumnName("vt_inc_vote_allocation_year");
            });

            modelBuilder.Entity<Programme>(entity =>
            {
                entity.ToTable("vt_programme");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID).HasColumnName("vt_programme_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("vt_programme_code");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_programme_name_english");

                entity.Property(e => e.NameSinhala)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("vt_programme_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_programme_name_tamil");

                entity.Property(e => e.SabhaID).HasColumnName("vt_programme_sabha_id");

                entity.Property(e => e.Status).HasColumnName("vt_programme_status");
            });

            modelBuilder.Entity<VoteDetail>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PRIMARY");

                entity.ToTable("vt_vote_details");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("vt_d_id");

                entity.Property(e => e.BalancesheetSubtitleID).HasColumnName("vt_d_balancesheet_subtitle_id");

                entity.Property(e => e.BalancesheetTitleID).HasColumnName("vt_d_balancesheet_title_id");

                entity.Property(e => e.IncomeOrExpense).HasColumnName("vt_d_income_or_expense");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_programme_code");

                entity.Property(e => e.ProgrammeID).HasColumnName("vt_d_programme_id");

                entity.Property(e => e.ProgrammeNameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_programme_name_english");

                entity.Property(e => e.ProgrammeNameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_programme_name_sinhala");

                entity.Property(e => e.ProgrammeNameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_programme_name_tamil");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_project_code");

                entity.Property(e => e.ProjectID).HasColumnName("vt_d_project_id");

                entity.Property(e => e.ProjectNameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_project_name_english");

                entity.Property(e => e.ProjectNameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_project_name_sinhala");

                entity.Property(e => e.ProjectNameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_project_name_tamil");

                entity.Property(e => e.SabhaCode)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_sabha_code");

                entity.Property(e => e.SabhaID).HasColumnName("vt_d_sabha_id");

                entity.Property(e => e.Status).HasColumnName("vt_d_status");

                entity.Property(e => e.SubprojectCode)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_subproject_code");

                entity.Property(e => e.SubprojectID).HasColumnName("vt_d_subproject_id");

                entity.Property(e => e.SubprojectNameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_subproject_name_english");

                entity.Property(e => e.SubprojectNameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_subproject_name_sinhala");

                entity.Property(e => e.SubprojectNameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_subproject_name_tamil");

                entity.Property(e => e.IncomeSubtitleCode)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_subtitle_code");

                entity.Property(e => e.IncomeSubtitleID).HasColumnName("vt_d_subtitle_id");

                entity.Property(e => e.IncomeSubtitleNameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_subtitle_name_english");

                entity.Property(e => e.IncomeSubtitleNameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_subtitle_name_sinhala");

                entity.Property(e => e.IncomeSubtitleNameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_subtitle_name_tamil");

                entity.Property(e => e.IncomeTitleCode)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_title_code");

                entity.Property(e => e.IncomeTitleID).HasColumnName("vt_d_title_id");

                entity.Property(e => e.IncomeTitleNameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_title_name_english");

                entity.Property(e => e.IncomeTitleNameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_title_name_sinhala");

                entity.Property(e => e.IncomeTitleNameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_title_name_tamil");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_vote_code");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_vote_name_english");

                entity.Property(e => e.NameSinhala)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_vote_name_sinhala");

                entity.Property(e => e.NameTamil)
                    .HasMaxLength(255)
                    .HasColumnName("vt_d_vote_name_tamil");

                entity.Property(e => e.VoteOrBal).HasColumnName("vt_d_vote_or_bal");

                entity.Property(e => e.VoteOrder).HasColumnName("vt_d_vote_order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}