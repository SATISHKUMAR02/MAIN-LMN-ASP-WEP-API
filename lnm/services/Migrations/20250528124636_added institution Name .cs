using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class addedinstitutionName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "MoumMouId",
                table: "mouMaster",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "MouMouType",
                table: "mouMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "connectorMousCmouMouNo",
                table: "mouMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "institutionMousImoMouNo",
                table: "mouMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MmInstitutionName",
                table: "meetingsMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<float>(
                name: "ImoMouId",
                table: "institutionMou",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CmouMouId",
                table: "connectorMou",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mouMaster_connectorMousCmouMouNo",
                table: "mouMaster",
                column: "connectorMousCmouMouNo");

            migrationBuilder.CreateIndex(
                name: "IX_mouMaster_institutionMousImoMouNo",
                table: "mouMaster",
                column: "institutionMousImoMouNo");

            migrationBuilder.CreateIndex(
                name: "IX_meetingsMaster_MmInstitutionId",
                table: "meetingsMaster",
                column: "MmInstitutionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_institutionActivity_ImActivityId",
                table: "institutionActivity",
                column: "ImActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_institutionActivity_ImInstitutionId",
                table: "institutionActivity",
                column: "ImInstitutionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InstitutionActivity_Activitymaster",
                table: "institutionActivity",
                column: "ImActivityId",
                principalTable: "activityMaster",
                principalColumn: "AmActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_institutionActivity_institutionMaster_ImInstitutionId",
                table: "institutionActivity",
                column: "ImInstitutionId",
                principalTable: "institutionMaster",
                principalColumn: "ImInstitutionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingMaster_Institutionmaster",
                table: "meetingsMaster",
                column: "MmInstitutionId",
                principalTable: "institutionMaster",
                principalColumn: "ImInstitutionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mouMaster_connectorMou_connectorMousCmouMouNo",
                table: "mouMaster",
                column: "connectorMousCmouMouNo",
                principalTable: "connectorMou",
                principalColumn: "CmouMouNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mouMaster_institutionMou_institutionMousImoMouNo",
                table: "mouMaster",
                column: "institutionMousImoMouNo",
                principalTable: "institutionMou",
                principalColumn: "ImoMouNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstitutionActivity_Activitymaster",
                table: "institutionActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_institutionActivity_institutionMaster_ImInstitutionId",
                table: "institutionActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingMaster_Institutionmaster",
                table: "meetingsMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_mouMaster_connectorMou_connectorMousCmouMouNo",
                table: "mouMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_mouMaster_institutionMou_institutionMousImoMouNo",
                table: "mouMaster");

            migrationBuilder.DropIndex(
                name: "IX_mouMaster_connectorMousCmouMouNo",
                table: "mouMaster");

            migrationBuilder.DropIndex(
                name: "IX_mouMaster_institutionMousImoMouNo",
                table: "mouMaster");

            migrationBuilder.DropIndex(
                name: "IX_meetingsMaster_MmInstitutionId",
                table: "meetingsMaster");

            migrationBuilder.DropIndex(
                name: "IX_institutionActivity_ImActivityId",
                table: "institutionActivity");

            migrationBuilder.DropIndex(
                name: "IX_institutionActivity_ImInstitutionId",
                table: "institutionActivity");

            migrationBuilder.DropColumn(
                name: "MouMouType",
                table: "mouMaster");

            migrationBuilder.DropColumn(
                name: "connectorMousCmouMouNo",
                table: "mouMaster");

            migrationBuilder.DropColumn(
                name: "institutionMousImoMouNo",
                table: "mouMaster");

            migrationBuilder.DropColumn(
                name: "MmInstitutionName",
                table: "meetingsMaster");

            migrationBuilder.AlterColumn<int>(
                name: "MoumMouId",
                table: "mouMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ImoMouId",
                table: "institutionMou",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CmouMouId",
                table: "connectorMou",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
