using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class AddedforeignkeybetweenforUserModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_login_details_uld_employee_id",
                table: "tbl_user_login_details",
                column: "uld_employee_id",
                unique: true,
                filter: "[uld_employee_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_employee_master_em_role_id",
                table: "tbl_employee_master",
                column: "em_role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeemaster_Roles",
                table: "tbl_employee_master",
                column: "em_role_id",
                principalTable: "tbl_role_master",
                principalColumn: "rm_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbluserlogindetails_EmployeeMaster",
                table: "tbl_user_login_details",
                column: "uld_employee_id",
                principalTable: "tbl_employee_master",
                principalColumn: "em_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeemaster_Roles",
                table: "tbl_employee_master");

            migrationBuilder.DropForeignKey(
                name: "FK_tbluserlogindetails_EmployeeMaster",
                table: "tbl_user_login_details");

            migrationBuilder.DropIndex(
                name: "IX_tbl_user_login_details_uld_employee_id",
                table: "tbl_user_login_details");

            migrationBuilder.DropIndex(
                name: "IX_tbl_employee_master_em_role_id",
                table: "tbl_employee_master");
        }
    }
}
