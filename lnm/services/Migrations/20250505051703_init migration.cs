using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activityMaster",
                columns: table => new
                {
                    AmActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmActivityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activityMaster", x => x.AmActivityId);
                });

            migrationBuilder.CreateTable(
                name: "connectorMou",
                columns: table => new
                {
                    CmouMouNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CmouMouId = table.Column<int>(type: "int", nullable: true),
                    CmouRoleId = table.Column<int>(type: "int", nullable: true),
                    CmouCreatedBy = table.Column<int>(type: "int", nullable: false),
                    CmouUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CmouCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CmouUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CmouMouVerionNo = table.Column<float>(type: "real", nullable: true),
                    CmouMouPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CmouMouDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_connectorMou", x => x.CmouMouNo);
                });

            migrationBuilder.CreateTable(
                name: "institutionActivity",
                columns: table => new
                {
                    ImInstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImActivityId = table.Column<int>(type: "int", nullable: false),
                    ImInstitutionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImInstitutionAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImInstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImStudentStrength = table.Column<int>(type: "int", nullable: false),
                    ImInstitutionStatus = table.Column<bool>(type: "bit", nullable: true),
                    ImPrincipalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImPrincipalContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImPrincipalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImOtherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImOtherDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImOtherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImAssignConnector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImCreatedBy = table.Column<int>(type: "int", nullable: false),
                    ImUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    ImCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImMouStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionActivity", x => x.ImInstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "institutionMaster",
                columns: table => new
                {
                    ImInstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImInstitutionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImInstitutionAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImInstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImStudentStrength = table.Column<int>(type: "int", nullable: false),
                    ImInstitutionStatus = table.Column<bool>(type: "bit", nullable: true),
                    ImPrincipalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImPrincipalContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImPrincipalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImOtherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImOtherDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImOtherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImAssignConnector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImCreatedBy = table.Column<int>(type: "int", nullable: false),
                    ImUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    ImCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImMouStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImIsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionMaster", x => x.ImInstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "institutionMou",
                columns: table => new
                {
                    ImoMouNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImoMouId = table.Column<int>(type: "int", nullable: true),
                    ImoInstitutionId = table.Column<int>(type: "int", nullable: true),
                    ImoCreatedBy = table.Column<int>(type: "int", nullable: true),
                    ImoUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    ImoCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImoUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImoMouVerionNo = table.Column<float>(type: "real", nullable: false),
                    ImoMouPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImoMouDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImoUploadedMou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImoDownloadedMou = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionMou", x => x.ImoMouNo);
                });

            migrationBuilder.CreateTable(
                name: "meetingsMaster",
                columns: table => new
                {
                    MmMeetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MmInstitutionId = table.Column<int>(type: "int", nullable: false),
                    MmMeetingDescritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MmCreatedBy = table.Column<int>(type: "int", nullable: false),
                    MmCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MmUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    MmInstitutionResponded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MmUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MmInstitutionAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MmMeetingTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    MmMeetingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MmMeetingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MmMeetingConducted = table.Column<bool>(type: "bit", nullable: false),
                    MmmeetingOutcome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meetingsMaster", x => x.MmMeetingId);
                });

            migrationBuilder.CreateTable(
                name: "mouMaster",
                columns: table => new
                {
                    MoumMouId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoumMouName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoumMouDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoumMouPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoumCreatedBy = table.Column<int>(type: "int", nullable: false),
                    MoumCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoumUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    MoumUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mouMaster", x => x.MoumMouId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employee_master",
                columns: table => new
                {
                    em_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    em_name_e = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    em_name_k = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    em_contact_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    em_role_id = table.Column<int>(type: "int", nullable: true),
                    em_email_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    em_residencial_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    em_joining_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    em_end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    em_is_active = table.Column<bool>(type: "bit", nullable: true),
                    em_created_by = table.Column<int>(type: "int", nullable: true),
                    em_updated_by = table.Column<int>(type: "int", nullable: true),
                    em_created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    em_updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employee_master", x => x.em_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role_master",
                columns: table => new
                {
                    rm_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rm_name_e = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rm_name_k = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rm_is_active = table.Column<bool>(type: "bit", nullable: true),
                    rm_created_by = table.Column<int>(type: "int", nullable: true),
                    rm_updated_by = table.Column<int>(type: "int", nullable: true),
                    rm_created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rm_updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role_master", x => x.rm_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_login_details",
                columns: table => new
                {
                    uld_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uld_contact_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uld_otp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uld_otp_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    uld_employee_id = table.Column<int>(type: "int", nullable: true),
                    uld_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uld_is_active = table.Column<bool>(type: "bit", nullable: true),
                    uld_created_by = table.Column<int>(type: "int", nullable: true),
                    uld_updated_by = table.Column<int>(type: "int", nullable: true),
                    uld_created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    uld_updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_login_details", x => x.uld_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activityMaster");

            migrationBuilder.DropTable(
                name: "connectorMou");

            migrationBuilder.DropTable(
                name: "institutionActivity");

            migrationBuilder.DropTable(
                name: "institutionMaster");

            migrationBuilder.DropTable(
                name: "institutionMou");

            migrationBuilder.DropTable(
                name: "meetingsMaster");

            migrationBuilder.DropTable(
                name: "mouMaster");

            migrationBuilder.DropTable(
                name: "tbl_employee_master");

            migrationBuilder.DropTable(
                name: "tbl_role_master");

            migrationBuilder.DropTable(
                name: "tbl_user_login_details");
        }
    }
}
