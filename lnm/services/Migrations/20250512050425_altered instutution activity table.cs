using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class alteredinstututionactivitytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImOtherEmail",
                table: "institutionActivity");

            migrationBuilder.DropColumn(
                name: "ImOtherName",
                table: "institutionActivity");

            migrationBuilder.DropColumn(
                name: "ImPrincipalEmail",
                table: "institutionActivity");

            migrationBuilder.DropColumn(
                name: "ImPrincipalName",
                table: "institutionActivity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImOtherEmail",
                table: "institutionActivity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImOtherName",
                table: "institutionActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImPrincipalEmail",
                table: "institutionActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImPrincipalName",
                table: "institutionActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
