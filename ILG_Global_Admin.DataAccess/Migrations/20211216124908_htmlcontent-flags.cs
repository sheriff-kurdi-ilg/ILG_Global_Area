using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global_Admin.DataAccess.Migrations
{
    public partial class htmlcontentflags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHasDescription",
                table: "HtmlContentMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHasSubTitle",
                table: "HtmlContentMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHasSummary",
                table: "HtmlContentMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHasTitle",
                table: "HtmlContentMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHasDescription",
                table: "HtmlContentMasters");

            migrationBuilder.DropColumn(
                name: "IsHasSubTitle",
                table: "HtmlContentMasters");

            migrationBuilder.DropColumn(
                name: "IsHasSummary",
                table: "HtmlContentMasters");

            migrationBuilder.DropColumn(
                name: "IsHasTitle",
                table: "HtmlContentMasters");
        }
    }
}
