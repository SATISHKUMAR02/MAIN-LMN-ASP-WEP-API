using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class updatedinstitutitonActivitytableattributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImInstitutionStatus",
                table: "institutionActivity");

            migrationBuilder.DropColumn(
                name: "ImMouStatus",
                table: "institutionActivity");

            migrationBuilder.DropColumn(
                name: "ImOtherDesignation",
                table: "institutionActivity");

            migrationBuilder.DropColumn(
                name: "ImPrincipalContact",
                table: "institutionActivity");

            migrationBuilder.AddColumn<int>(
                name: "ImStudentParticipating",
                table: "institutionActivity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfDaysEvent",
                table: "institutionActivity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImStudentParticipating",
                table: "institutionActivity");

            migrationBuilder.DropColumn(
                name: "NoOfDaysEvent",
                table: "institutionActivity");

            migrationBuilder.AddColumn<bool>(
                name: "ImInstitutionStatus",
                table: "institutionActivity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImMouStatus",
                table: "institutionActivity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImOtherDesignation",
                table: "institutionActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImPrincipalContact",
                table: "institutionActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
