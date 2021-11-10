using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class OurServicesTableAdded5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ImageDetails");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ImageMasters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ImageMasters");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ImageDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
