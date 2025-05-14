using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class withinstitutionAtivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "institutionActivity",
                columns: table => new
                {
                    ImSlno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImInstitutionId = table.Column<int>(type: "int", nullable: false),
                    ImActivityId = table.Column<int>(type: "int", nullable: false),
                    ImInstitutionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImInstitutionAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImInstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImStudentStrength = table.Column<int>(type: "int", nullable: false),
                    ImActivityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImAssignConnector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImCreatedBy = table.Column<int>(type: "int", nullable: false),
                    ImUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    ImCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImScheduleDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ImStudentParticipating = table.Column<int>(type: "int", nullable: false),
                    NoOfDaysEvent = table.Column<int>(type: "int", nullable: false),
                    ImEventVenue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImIsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionActivity", x => x.ImSlno);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "institutionActivity");
        }
    }
}
