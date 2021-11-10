using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class OurServicesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageMasters_HtmlContentMasters_HtmlContentMasterID",
                table: "ImageMasters");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "SucessStoryMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HtmlContentMasterID",
                table: "ImageMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OurServiceMasterID",
                table: "ImageMasters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OurServiceMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServiceMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OurServiceDetails",
                columns: table => new
                {
                    OurServiceID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServiceDetails", x => new { x.LanguageCode, x.OurServiceID });
                    table.ForeignKey(
                        name: "FK_OurServiceDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OurServiceDetails_OurServiceMasters_OurServiceID",
                        column: x => x.OurServiceID,
                        principalTable: "OurServiceMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OurServiceDetails_OurServiceID",
                table: "OurServiceDetails",
                column: "OurServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageMasters_HtmlContentMasters_HtmlContentMasterID",
                table: "ImageMasters",
                column: "HtmlContentMasterID",
                principalTable: "HtmlContentMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageMasters_HtmlContentMasters_HtmlContentMasterID",
                table: "ImageMasters");

            migrationBuilder.DropTable(
                name: "OurServiceDetails");

            migrationBuilder.DropTable(
                name: "OurServiceMasters");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "SucessStoryMasters");

            migrationBuilder.DropColumn(
                name: "OurServiceMasterID",
                table: "ImageMasters");

            migrationBuilder.AlterColumn<int>(
                name: "HtmlContentMasterID",
                table: "ImageMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageMasters_HtmlContentMasters_HtmlContentMasterID",
                table: "ImageMasters",
                column: "HtmlContentMasterID",
                principalTable: "HtmlContentMasters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
