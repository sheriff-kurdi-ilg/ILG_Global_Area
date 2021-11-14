using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageMastersId",
                table: "OurServiceMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageMastersId",
                table: "ImageMasters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OurServiceMasterID",
                table: "ImageDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageMasters_ImageMastersId",
                table: "ImageMasters",
                column: "ImageMastersId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageMasters_OurServiceMasterID",
                table: "ImageMasters",
                column: "OurServiceMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_OurServiceMasterID",
                table: "ImageDetails",
                column: "OurServiceMasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageDetails_OurServiceMasters_OurServiceMasterID",
                table: "ImageDetails",
                column: "OurServiceMasterID",
                principalTable: "OurServiceMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageMasters_OurServiceMasters_ImageMastersId",
                table: "ImageMasters",
                column: "ImageMastersId",
                principalTable: "OurServiceMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageMasters_OurServiceMasters_OurServiceMasterID",
                table: "ImageMasters",
                column: "OurServiceMasterID",
                principalTable: "OurServiceMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageDetails_OurServiceMasters_OurServiceMasterID",
                table: "ImageDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageMasters_OurServiceMasters_ImageMastersId",
                table: "ImageMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageMasters_OurServiceMasters_OurServiceMasterID",
                table: "ImageMasters");

            migrationBuilder.DropIndex(
                name: "IX_ImageMasters_ImageMastersId",
                table: "ImageMasters");

            migrationBuilder.DropIndex(
                name: "IX_ImageMasters_OurServiceMasterID",
                table: "ImageMasters");

            migrationBuilder.DropIndex(
                name: "IX_ImageDetails_OurServiceMasterID",
                table: "ImageDetails");

            migrationBuilder.DropColumn(
                name: "ImageMastersId",
                table: "OurServiceMasters");

            migrationBuilder.DropColumn(
                name: "ImageMastersId",
                table: "ImageMasters");

            migrationBuilder.DropColumn(
                name: "OurServiceMasterID",
                table: "ImageDetails");
        }
    }
}
