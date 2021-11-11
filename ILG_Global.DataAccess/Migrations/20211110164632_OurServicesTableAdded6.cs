using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class OurServicesTableAdded6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SucessStoryDetails",
                table: "SucessStoryDetails");

            migrationBuilder.DropIndex(
                name: "IX_SucessStoryDetails_SucessStoryID",
                table: "SucessStoryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OurServiceDetails",
                table: "OurServiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_OurServiceDetails_OurServiceID",
                table: "OurServiceDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageDetails",
                table: "ImageDetails");

            migrationBuilder.DropIndex(
                name: "IX_ImageDetails_ImageID",
                table: "ImageDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HtmlContentDetails",
                table: "HtmlContentDetails");

            migrationBuilder.DropIndex(
                name: "IX_HtmlContentDetails_HtmlContentID",
                table: "HtmlContentDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SucessStoryDetails",
                table: "SucessStoryDetails",
                columns: new[] { "SucessStoryID", "LanguageCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OurServiceDetails",
                table: "OurServiceDetails",
                columns: new[] { "OurServiceID", "LanguageCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageDetails",
                table: "ImageDetails",
                columns: new[] { "ImageID", "LanguageCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HtmlContentDetails",
                table: "HtmlContentDetails",
                columns: new[] { "HtmlContentID", "LanguageCode" });

            migrationBuilder.CreateTable(
                name: "ContactInformationMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FontAwsomeIconCssClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformationMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformationDetails",
                columns: table => new
                {
                    ContactInformationID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformationDetails", x => new { x.ContactInformationID, x.LanguageCode });
                    table.ForeignKey(
                        name: "FK_ContactInformationDetails_ContactInformationMasters_ContactInformationID",
                        column: x => x.ContactInformationID,
                        principalTable: "ContactInformationMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactInformationDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SucessStoryDetails_LanguageCode",
                table: "SucessStoryDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_OurServiceDetails_LanguageCode",
                table: "OurServiceDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_LanguageCode",
                table: "ImageDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlContentDetails_LanguageCode",
                table: "HtmlContentDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformationDetails_LanguageCode",
                table: "ContactInformationDetails",
                column: "LanguageCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInformationDetails");

            migrationBuilder.DropTable(
                name: "ContactInformationMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SucessStoryDetails",
                table: "SucessStoryDetails");

            migrationBuilder.DropIndex(
                name: "IX_SucessStoryDetails_LanguageCode",
                table: "SucessStoryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OurServiceDetails",
                table: "OurServiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_OurServiceDetails_LanguageCode",
                table: "OurServiceDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageDetails",
                table: "ImageDetails");

            migrationBuilder.DropIndex(
                name: "IX_ImageDetails_LanguageCode",
                table: "ImageDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HtmlContentDetails",
                table: "HtmlContentDetails");

            migrationBuilder.DropIndex(
                name: "IX_HtmlContentDetails_LanguageCode",
                table: "HtmlContentDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SucessStoryDetails",
                table: "SucessStoryDetails",
                columns: new[] { "LanguageCode", "SucessStoryID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OurServiceDetails",
                table: "OurServiceDetails",
                columns: new[] { "LanguageCode", "OurServiceID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageDetails",
                table: "ImageDetails",
                columns: new[] { "LanguageCode", "ImageID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HtmlContentDetails",
                table: "HtmlContentDetails",
                columns: new[] { "LanguageCode", "HtmlContentID" });

            migrationBuilder.CreateIndex(
                name: "IX_SucessStoryDetails_SucessStoryID",
                table: "SucessStoryDetails",
                column: "SucessStoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OurServiceDetails_OurServiceID",
                table: "OurServiceDetails",
                column: "OurServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_ImageID",
                table: "ImageDetails",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlContentDetails_HtmlContentID",
                table: "HtmlContentDetails",
                column: "HtmlContentID");
        }
    }
}
