using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class FixedbyHesham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrefairedLanguage",
                table: "NewsLetterSubscribes",
                newName: "PreferredLanguage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreferredLanguage",
                table: "NewsLetterSubscribes",
                newName: "PrefairedLanguage");
        }
    }
}
