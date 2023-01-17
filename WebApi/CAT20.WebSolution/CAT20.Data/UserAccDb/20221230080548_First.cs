using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAT20.Data.UserAccDb
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "u_previledges",
                columns: table => new
                {
                    up_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    up_name_sinhala = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    up_name_english = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    up_name_tamil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    up_status = table.Column<int>(type: "int", nullable: true),
                    up_office_id = table.Column<int>(type: "int", nullable: true),
                    up_sabha_id = table.Column<int>(type: "int", nullable: true),
                    up_description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.up_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "user_details",
                columns: table => new
                {
                    ud_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ud_name_in_full = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ud_name_with_initials = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ud_username = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ud_password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ud_nic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ud_contact_no = table.Column<int>(type: "int", nullable: true),
                    ud_birthday = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ud_sabha_id = table.Column<int>(type: "int", nullable: true),
                    ud_office_id = table.Column<int>(type: "int", nullable: true),
                    ud_active_status = table.Column<int>(type: "int", nullable: true),
                    ud_gender_id = table.Column<int>(type: "int", nullable: true, comment: "control db fk"),
                    ud_profile_pic_path = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ud_q1_id = table.Column<int>(type: "int", nullable: true),
                    ud_answer1 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ud_q2_id = table.Column<int>(type: "int", nullable: true),
                    ud_answer2 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ud_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "user_recover_questions",
                columns: table => new
                {
                    user_recover_questions_id = table.Column<int>(type: "int", nullable: false),
                    user_recover_questions = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_recover_questions", x => x.user_recover_questions_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "user_has_previledges",
                columns: table => new
                {
                    uhp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uhp_user_det_id = table.Column<int>(type: "int", nullable: false),
                    uhp_user_priv_id = table.Column<int>(type: "int", nullable: false),
                    uhp_status = table.Column<int>(type: "int", nullable: true),
                    uhp_sabha_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uhp_id);
                    table.ForeignKey(
                        name: "fk_uhp_user_det_id",
                        column: x => x.uhp_user_det_id,
                        principalTable: "user_details",
                        principalColumn: "ud_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_uhp_user_priv_id",
                        column: x => x.uhp_user_priv_id,
                        principalTable: "u_previledges",
                        principalColumn: "up_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_uhp_user_det_id",
                table: "user_has_previledges",
                column: "uhp_user_det_id");

            migrationBuilder.CreateIndex(
                name: "fk_uhp_user_priv_id",
                table: "user_has_previledges",
                column: "uhp_user_priv_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_has_previledges");

            migrationBuilder.DropTable(
                name: "user_recover_questions");

            migrationBuilder.DropTable(
                name: "user_details");

            migrationBuilder.DropTable(
                name: "u_previledges");
        }
    }
}
