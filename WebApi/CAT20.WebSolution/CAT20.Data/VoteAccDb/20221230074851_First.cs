using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAT20.Data.VoteAccDb
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "account_details",
                columns: table => new
                {
                    acc_d_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    acc_d_acc_no = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    acc_d_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    acc_d_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    acc_d_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    acc_d_bank_id = table.Column<int>(type: "int", nullable: true, comment: "control db fk"),
                    acc_d_status = table.Column<int>(type: "int", nullable: true),
                    acc_d_office_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.acc_d_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_balancesheet_balance",
                columns: table => new
                {
                    vt_balancesheet_bal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vt_balancesheet_bal_vote_id = table.Column<int>(type: "int", nullable: false),
                    vt_balancesheet_bal_year = table.Column<int>(type: "int", nullable: true),
                    vt_balancesheet_bal_balance = table.Column<double>(type: "double", nullable: false),
                    vt_balancesheet_bal_comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_balancesheet_bal_enter_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    vt_balancesheet_bal_sabha_id = table.Column<int>(type: "int", nullable: false),
                    vt_balancesheet_bal_status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.vt_balancesheet_bal_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_balsheet_title",
                columns: table => new
                {
                    vt_balsheet_title_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vt_balsheet_title_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_balsheet_title_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_balsheet_title_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_balsheet_title_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_balsheet_title_balpath = table.Column<int>(type: "int", nullable: true),
                    vt_balsheet_title_status = table.Column<int>(type: "int", nullable: true),
                    vt_balsheet_title_sabha_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vt_balsheet_title", x => x.vt_balsheet_title_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_inc_vote_allocation",
                columns: table => new
                {
                    vt_inc_vote_allocation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vt_inc_vote_allocation_vote_id = table.Column<int>(type: "int", nullable: true),
                    vt_inc_vote_allocation_allocation_amount = table.Column<double>(type: "double", nullable: true),
                    vt_inc_vote_allocation_inc_amount = table.Column<double>(type: "double", nullable: true),
                    vt_inc_vote_allocation_create_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    vt_inc_vote_allocation_year = table.Column<int>(type: "int", nullable: true),
                    vt_inc_vote_allocation_status = table.Column<int>(type: "int", nullable: true),
                    vt_inc_vote_allocation_sabha_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vt_inc_vote_allocation", x => x.vt_inc_vote_allocation_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_programme",
                columns: table => new
                {
                    vt_programme_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vt_programme_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_programme_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_programme_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_programme_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_programme_status = table.Column<int>(type: "int", nullable: true),
                    vt_programme_sabha_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vt_programme", x => x.vt_programme_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_vote_details",
                columns: table => new
                {
                    vt_d_id = table.Column<int>(type: "int", nullable: false),
                    vt_d_vote_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_vote_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_vote_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_vote_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_vote_order = table.Column<int>(type: "int", nullable: true),
                    vt_d_programme_id = table.Column<int>(type: "int", nullable: true),
                    vt_d_programme_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_programme_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_programme_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ProgrammeCode = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_project_id = table.Column<int>(type: "int", nullable: true),
                    vt_d_project_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_project_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_project_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_project_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_subproject_id = table.Column<int>(type: "int", nullable: true),
                    vt_d_subproject_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_subproject_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_subproject_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_subproject_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_title_id = table.Column<int>(type: "int", nullable: true),
                    vt_d_title_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_title_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_title_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_title_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_subtitle_id = table.Column<int>(type: "int", nullable: false),
                    vt_d_subtitle_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_subtitle_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_subtitle_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_subtitle_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_income_or_expense = table.Column<int>(type: "int", nullable: true),
                    vt_d_vote_or_bal = table.Column<int>(type: "int", nullable: true),
                    vt_d_sabha_id = table.Column<int>(type: "int", nullable: true),
                    vt_d_sabha_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_d_status = table.Column<int>(type: "int", nullable: true),
                    vt_d_balancesheet_title_id = table.Column<int>(type: "int", nullable: true),
                    vt_d_balancesheet_subtitle_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.vt_d_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "account_bal_details",
                columns: table => new
                {
                    acc_bd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    acc_bd_acc_d_id = table.Column<int>(type: "int", nullable: false),
                    acc_bd_year = table.Column<int>(type: "int", nullable: true),
                    acc_bd_bal_amount = table.Column<double>(type: "double", nullable: false),
                    acc_bd_enter_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    acc_bd_status = table.Column<int>(type: "int", nullable: false),
                    acc_sabha_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.acc_bd_id);
                    table.ForeignKey(
                        name: "fk_acc_bd_acc_d_id",
                        column: x => x.acc_bd_acc_d_id,
                        principalTable: "account_details",
                        principalColumn: "acc_d_id");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_balsheet_subtitle",
                columns: table => new
                {
                    vt_balsheet_subtitle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vt_balsheet_subtitle_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_balsheet_subtitle_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_balsheet_subtitle_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_balsheet_subtitle_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_balsheet_subtitle_title_id = table.Column<int>(type: "int", nullable: true),
                    vt_balsheet_subtitle_status = table.Column<int>(type: "int", nullable: true),
                    vt_balsheet_subtitle_sabha_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vt_balsheet_subtitle", x => x.vt_balsheet_subtitle_id);
                    table.ForeignKey(
                        name: "fk_vt_balsheet_subtitle_title_id",
                        column: x => x.vt_balsheet_subtitle_title_id,
                        principalTable: "vt_balsheet_title",
                        principalColumn: "vt_balsheet_title_id");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_inc_project",
                columns: table => new
                {
                    vt_inc_project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vt_inc_project_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_project_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_project_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_project_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_project_status = table.Column<int>(type: "int", nullable: true),
                    vt_inc_project_programme_id = table.Column<int>(type: "int", nullable: true),
                    vt_inc_project_sabha_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vt_inc_project", x => x.vt_inc_project_id);
                    table.ForeignKey(
                        name: "fk_vt_inc_project_programme_id",
                        column: x => x.vt_inc_project_programme_id,
                        principalTable: "vt_programme",
                        principalColumn: "vt_programme_id");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_inc_title",
                columns: table => new
                {
                    vt_inc_title_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vt_inc_title_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_title_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_title_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_title_name_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_title_status = table.Column<int>(type: "int", nullable: true),
                    vt_inc_title_programme_id = table.Column<int>(type: "int", nullable: true),
                    vt_inc_title_sabha_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vt_inc_title", x => x.vt_inc_title_id);
                    table.ForeignKey(
                        name: "fk_vt_inc_title_name_programme_id",
                        column: x => x.vt_inc_title_programme_id,
                        principalTable: "vt_programme",
                        principalColumn: "vt_programme_id");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_inc_sub_project",
                columns: table => new
                {
                    vt_inc_sub_project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vt_inc_sub_project_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_sub_project_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_sub_project_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_sub_project_name_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_sub_project_status = table.Column<int>(type: "int", nullable: true),
                    vt_inc_sub_project_project_id = table.Column<int>(type: "int", nullable: false),
                    vt_inc_sub_project_sabha_id = table.Column<int>(type: "int", nullable: true),
                    vt_inc_sub_project_programme_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vt_inc_sub_project", x => x.vt_inc_sub_project_id);
                    table.ForeignKey(
                        name: "fk_vt_inc_sub_project_project_id",
                        column: x => x.vt_inc_sub_project_project_id,
                        principalTable: "vt_inc_project",
                        principalColumn: "vt_inc_project_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "vt_inc_subtitle",
                columns: table => new
                {
                    vt_inc_subtitle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vt_inc_subtitle_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_subtitle_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_subtitle_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_subtitle_name_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    vt_inc_subtitle_title_id = table.Column<int>(type: "int", nullable: false),
                    vt_inc_subtitle_status = table.Column<int>(type: "int", nullable: true),
                    vt_inc_subtitle_sabha_id = table.Column<int>(type: "int", nullable: true),
                    vt_inc_subtitle_programme_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vt_inc_subtitle", x => x.vt_inc_subtitle_id);
                    table.ForeignKey(
                        name: "fk_vt_inc_subtitle_title_id",
                        column: x => x.vt_inc_subtitle_title_id,
                        principalTable: "vt_inc_title",
                        principalColumn: "vt_inc_title_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_acc_bd_acc_d_id",
                table: "account_bal_details",
                column: "acc_bd_acc_d_id");

            migrationBuilder.CreateIndex(
                name: "fk_vt_balsheet_subtitle_title_id",
                table: "vt_balsheet_subtitle",
                column: "vt_balsheet_subtitle_title_id");

            migrationBuilder.CreateIndex(
                name: "fk_vt_inc_project_programme_id",
                table: "vt_inc_project",
                column: "vt_inc_project_programme_id");

            migrationBuilder.CreateIndex(
                name: "fk_vt_inc_sub_project_project_id",
                table: "vt_inc_sub_project",
                column: "vt_inc_sub_project_project_id");

            migrationBuilder.CreateIndex(
                name: "fk_vt_inc_subtitle_title_id",
                table: "vt_inc_subtitle",
                column: "vt_inc_subtitle_title_id");

            migrationBuilder.CreateIndex(
                name: "fk_vt_inc_title_name_programme_id",
                table: "vt_inc_title",
                column: "vt_inc_title_programme_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_bal_details");

            migrationBuilder.DropTable(
                name: "vt_balancesheet_balance");

            migrationBuilder.DropTable(
                name: "vt_balsheet_subtitle");

            migrationBuilder.DropTable(
                name: "vt_inc_sub_project");

            migrationBuilder.DropTable(
                name: "vt_inc_subtitle");

            migrationBuilder.DropTable(
                name: "vt_inc_vote_allocation");

            migrationBuilder.DropTable(
                name: "vt_vote_details");

            migrationBuilder.DropTable(
                name: "account_details");

            migrationBuilder.DropTable(
                name: "vt_balsheet_title");

            migrationBuilder.DropTable(
                name: "vt_inc_project");

            migrationBuilder.DropTable(
                name: "vt_inc_title");

            migrationBuilder.DropTable(
                name: "vt_programme");
        }
    }
}
