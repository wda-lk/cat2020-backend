using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAT20.Data.VoteAccDb
{
    public partial class votetableupdt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "vt_d_title_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_title_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_title_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_title_id",
                table: "vt_vote_details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_title_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subtitle_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subtitle_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subtitle_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subtitle_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subproject_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subproject_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subproject_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_subproject_id",
                table: "vt_vote_details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subproject_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_status",
                table: "vt_vote_details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_sabha_id",
                table: "vt_vote_details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_sabha_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_project_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_project_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_project_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_project_id",
                table: "vt_vote_details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_project_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_programme_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_programme_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_programme_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_programme_id",
                table: "vt_vote_details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProgrammeCode",
                table: "vt_vote_details",
                type: "longtext",
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_title_name_tamil",
                keyValue: null,
                column: "vt_d_title_name_tamil",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_title_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_title_name_sinhala",
                keyValue: null,
                column: "vt_d_title_name_sinhala",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_title_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_title_name_english",
                keyValue: null,
                column: "vt_d_title_name_english",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_title_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_title_id",
                table: "vt_vote_details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_title_code",
                keyValue: null,
                column: "vt_d_title_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_title_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_subtitle_name_tamil",
                keyValue: null,
                column: "vt_d_subtitle_name_tamil",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subtitle_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_subtitle_name_sinhala",
                keyValue: null,
                column: "vt_d_subtitle_name_sinhala",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subtitle_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_subtitle_name_english",
                keyValue: null,
                column: "vt_d_subtitle_name_english",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subtitle_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_subtitle_code",
                keyValue: null,
                column: "vt_d_subtitle_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subtitle_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_subproject_name_tamil",
                keyValue: null,
                column: "vt_d_subproject_name_tamil",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subproject_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_subproject_name_sinhala",
                keyValue: null,
                column: "vt_d_subproject_name_sinhala",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subproject_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_subproject_name_english",
                keyValue: null,
                column: "vt_d_subproject_name_english",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subproject_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_subproject_id",
                table: "vt_vote_details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_subproject_code",
                keyValue: null,
                column: "vt_d_subproject_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_subproject_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_status",
                table: "vt_vote_details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_sabha_id",
                table: "vt_vote_details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_sabha_code",
                keyValue: null,
                column: "vt_d_sabha_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_sabha_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_project_name_tamil",
                keyValue: null,
                column: "vt_d_project_name_tamil",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_project_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_project_name_sinhala",
                keyValue: null,
                column: "vt_d_project_name_sinhala",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_project_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_project_name_english",
                keyValue: null,
                column: "vt_d_project_name_english",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_project_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_project_id",
                table: "vt_vote_details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_project_code",
                keyValue: null,
                column: "vt_d_project_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_project_code",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_programme_name_tamil",
                keyValue: null,
                column: "vt_d_programme_name_tamil",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_programme_name_tamil",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_programme_name_sinhala",
                keyValue: null,
                column: "vt_d_programme_name_sinhala",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_programme_name_sinhala",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "vt_d_programme_name_english",
                keyValue: null,
                column: "vt_d_programme_name_english",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "vt_d_programme_name_english",
                table: "vt_vote_details",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "vt_d_programme_id",
                table: "vt_vote_details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "vt_vote_details",
                keyColumn: "ProgrammeCode",
                keyValue: null,
                column: "ProgrammeCode",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProgrammeCode",
                table: "vt_vote_details",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");
        }
    }
}
