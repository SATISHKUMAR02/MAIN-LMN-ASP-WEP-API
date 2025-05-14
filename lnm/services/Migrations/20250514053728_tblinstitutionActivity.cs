using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class tblinstitutionActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.DropColumn(
            //   name: "ImSlno",
            //   table: "TblInstitutionActivity");

            //// Add it back with IDENTITY
            //migrationBuilder.AddColumn<int>(
            //    name: "ImSlno",
            //    table: "TblInstitutionActivity",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
