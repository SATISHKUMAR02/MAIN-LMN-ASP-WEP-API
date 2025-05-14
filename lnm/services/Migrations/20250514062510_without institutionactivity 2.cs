using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class withoutinstitutionactivity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblInstitutionActivity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblInstitutionActivity",
                columns: table => new
                {
                    ImInstitutionId = table.Column<int>(type: "int", nullable: false),
                    ImActivityId = table.Column<int>(type: "int", nullable: false),
                    ImActivityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImAssignConnector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImCreatedBy = table.Column<int>(type: "int", nullable: false),
                    ImCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImEventVenue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImInstitutionAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImInstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImInstitutionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImIsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ImScheduleDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ImSlno = table.Column<int>(type: "int", nullable: false),
                    ImStudentParticipating = table.Column<int>(type: "int", nullable: false),
                    ImStudentStrength = table.Column<int>(type: "int", nullable: false),
                    ImUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    ImUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoOfDaysEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInstitutionActivity", x => new { x.ImInstitutionId, x.ImActivityId });
                });
        }
    }
}
