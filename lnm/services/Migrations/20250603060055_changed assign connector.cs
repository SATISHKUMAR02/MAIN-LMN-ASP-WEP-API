using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class changedassignconnector : Migration
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
                    CmouMouId = table.Column<float>(type: "real", nullable: true),
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
                name: "institutionMaster",
                columns: table => new
                {
                    ImInstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImInstitutionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImInstitutionAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImInstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImStudentStrength = table.Column<int>(type: "int", nullable: false),
                    ImInstitutionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImPrincipalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImPrincipalContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImPrincipalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImOtherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImOtherDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImOtherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImOtherContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImAssignConnector = table.Column<int>(type: "int", nullable: true),
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
                    ImoMouId = table.Column<float>(type: "real", nullable: true),
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
                    ImAssignConnector = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_InstitutionActivity_Activitymaster",
                        column: x => x.ImActivityId,
                        principalTable: "activityMaster",
                        principalColumn: "AmActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_institutionActivity_institutionMaster_ImInstitutionId",
                        column: x => x.ImInstitutionId,
                        principalTable: "institutionMaster",
                        principalColumn: "ImInstitutionId",
                        onDelete: ReferentialAction.Cascade);
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
                    MmMeetingScheduleDate = table.Column<DateOnly>(type: "date", nullable: true),
                    MmUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    MmInstitutionResponded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MmUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MmInstitutionAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MmMeetingTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    MmMeetingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MmMeetingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MmMeetingConducted = table.Column<bool>(type: "bit", nullable: false),
                    MmmeetingOutcome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MmIsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MmInstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meetingsMaster", x => x.MmMeetingId);
                    table.ForeignKey(
                        name: "FK_MeetingMaster_Institutionmaster",
                        column: x => x.MmInstitutionId,
                        principalTable: "institutionMaster",
                        principalColumn: "ImInstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mouMaster",
                columns: table => new
                {
                    MoumMouId = table.Column<float>(type: "real", nullable: false),
                    MouMouType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoumMouName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoumMouDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoumMouPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoumCreatedBy = table.Column<int>(type: "int", nullable: false),
                    MoumCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoumUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    MoumUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    connectorMousCmouMouNo = table.Column<int>(type: "int", nullable: false),
                    institutionMousImoMouNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mouMaster", x => x.MoumMouId);
                    table.ForeignKey(
                        name: "FK_mouMaster_connectorMou_connectorMousCmouMouNo",
                        column: x => x.connectorMousCmouMouNo,
                        principalTable: "connectorMou",
                        principalColumn: "CmouMouNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mouMaster_institutionMou_institutionMousImoMouNo",
                        column: x => x.institutionMousImoMouNo,
                        principalTable: "institutionMou",
                        principalColumn: "ImoMouNo",
                        onDelete: ReferentialAction.Cascade);
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
                    em_updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    em_gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dob = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employee_master", x => x.em_id);
                    table.ForeignKey(
                        name: "FK_employeemaster_Roles",
                        column: x => x.em_role_id,
                        principalTable: "tbl_role_master",
                        principalColumn: "rm_id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_tbluserlogindetails_EmployeeMaster",
                        column: x => x.uld_employee_id,
                        principalTable: "tbl_employee_master",
                        principalColumn: "em_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_institutionActivity_ImActivityId",
                table: "institutionActivity",
                column: "ImActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_institutionActivity_ImInstitutionId",
                table: "institutionActivity",
                column: "ImInstitutionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_meetingsMaster_MmInstitutionId",
                table: "meetingsMaster",
                column: "MmInstitutionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mouMaster_connectorMousCmouMouNo",
                table: "mouMaster",
                column: "connectorMousCmouMouNo");

            migrationBuilder.CreateIndex(
                name: "IX_mouMaster_institutionMousImoMouNo",
                table: "mouMaster",
                column: "institutionMousImoMouNo");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employee_master_em_role_id",
                table: "tbl_employee_master",
                column: "em_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_login_details_uld_employee_id",
                table: "tbl_user_login_details",
                column: "uld_employee_id",
                unique: true,
                filter: "[uld_employee_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "institutionActivity");

            migrationBuilder.DropTable(
                name: "meetingsMaster");

            migrationBuilder.DropTable(
                name: "mouMaster");

            migrationBuilder.DropTable(
                name: "tbl_user_login_details");

            migrationBuilder.DropTable(
                name: "activityMaster");

            migrationBuilder.DropTable(
                name: "institutionMaster");

            migrationBuilder.DropTable(
                name: "connectorMou");

            migrationBuilder.DropTable(
                name: "institutionMou");

            migrationBuilder.DropTable(
                name: "tbl_employee_master");

            migrationBuilder.DropTable(
                name: "tbl_role_master");
        }
    }
}
