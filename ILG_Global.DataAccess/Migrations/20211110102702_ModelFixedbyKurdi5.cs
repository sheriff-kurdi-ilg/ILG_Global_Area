using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class ModelFixedbyKurdi5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HtmlContentMasters_ImageMasters_ImageMasterId",
                table: "HtmlContentMasters");

            migrationBuilder.DropIndex(
                name: "IX_HtmlContentMasters_ImageMasterId",
                table: "HtmlContentMasters");

            migrationBuilder.DropColumn(
                name: "ImageMasterId",
                table: "HtmlContentMasters");

            migrationBuilder.CreateIndex(
                name: "IX_ImageMasters_HtmlContentMasterID",
                table: "ImageMasters",
                column: "HtmlContentMasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageMasters_HtmlContentMasters_HtmlContentMasterID",
                table: "ImageMasters",
                column: "HtmlContentMasterID",
                principalTable: "HtmlContentMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageMasters_HtmlContentMasters_HtmlContentMasterID",
                table: "ImageMasters");

            migrationBuilder.DropIndex(
                name: "IX_ImageMasters_HtmlContentMasterID",
                table: "ImageMasters");

            migrationBuilder.AddColumn<int>(
                name: "ImageMasterId",
                table: "HtmlContentMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HtmlContentMasters_ImageMasterId",
                table: "HtmlContentMasters",
                column: "ImageMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_HtmlContentMasters_ImageMasters_ImageMasterId",
                table: "HtmlContentMasters",
                column: "ImageMasterId",
                principalTable: "ImageMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
