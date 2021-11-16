using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class AddedSummaryToSuccessStoryDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "SucessStoryDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "SucessStoryDetails");
        }
    }
}
