using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class ModelFixedbyKurdi6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SucessStoryDetails_SucessStoryMasters_SucessStoryMasterID",
                table: "SucessStoryDetails");

            migrationBuilder.DropIndex(
                name: "IX_SucessStoryDetails_SucessStoryMasterID",
                table: "SucessStoryDetails");

            migrationBuilder.DropColumn(
                name: "SucessStoryMasterID",
                table: "SucessStoryDetails");

            migrationBuilder.CreateIndex(
                name: "IX_SucessStoryDetails_SucessStoryID",
                table: "SucessStoryDetails",
                column: "SucessStoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_SucessStoryDetails_SucessStoryMasters_SucessStoryID",
                table: "SucessStoryDetails",
                column: "SucessStoryID",
                principalTable: "SucessStoryMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SucessStoryDetails_SucessStoryMasters_SucessStoryID",
                table: "SucessStoryDetails");

            migrationBuilder.DropIndex(
                name: "IX_SucessStoryDetails_SucessStoryID",
                table: "SucessStoryDetails");

            migrationBuilder.AddColumn<int>(
                name: "SucessStoryMasterID",
                table: "SucessStoryDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SucessStoryDetails_SucessStoryMasterID",
                table: "SucessStoryDetails",
                column: "SucessStoryMasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_SucessStoryDetails_SucessStoryMasters_SucessStoryMasterID",
                table: "SucessStoryDetails",
                column: "SucessStoryMasterID",
                principalTable: "SucessStoryMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
