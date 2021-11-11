using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class ModelFixedbyKurdi4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SectionMasterID",
                table: "ImageMasters",
                newName: "HtmlContentMasterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HtmlContentMasterID",
                table: "ImageMasters",
                newName: "SectionMasterID");
        }
    }
}
