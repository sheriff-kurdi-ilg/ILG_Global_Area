using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class yyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageDetails_OurServiceMasters_OurServiceMasterID",
                table: "ImageDetails");

            migrationBuilder.AlterColumn<int>(
                name: "OurServiceMasterID",
                table: "ImageDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageDetails_OurServiceMasters_OurServiceMasterID",
                table: "ImageDetails",
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

            migrationBuilder.AlterColumn<int>(
                name: "OurServiceMasterID",
                table: "ImageDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageDetails_OurServiceMasters_OurServiceMasterID",
                table: "ImageDetails",
                column: "OurServiceMasterID",
                principalTable: "OurServiceMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
