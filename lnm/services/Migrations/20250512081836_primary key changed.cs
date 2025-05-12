using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class primarykeychanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_institutionActivity",
                table: "institutionActivity");

            migrationBuilder.AlterColumn<int>(
                name: "ImInstitutionId",
                table: "institutionActivity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ImSlno",
                table: "institutionActivity",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_institutionActivity",
                table: "institutionActivity",
                column: "ImSlno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_institutionActivity",
                table: "institutionActivity");

            migrationBuilder.DropColumn(
                name: "ImSlno",
                table: "institutionActivity");

            migrationBuilder.AlterColumn<int>(
                name: "ImInstitutionId",
                table: "institutionActivity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_institutionActivity",
                table: "institutionActivity",
                column: "ImInstitutionId");
        }
    }
}
