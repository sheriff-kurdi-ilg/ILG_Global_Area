using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class ModelFixedbyKurdi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionMasterID = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SucessStoryMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucessStoryMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HtmlContentMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageMasterId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CanBeDeletedByUser = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlContentMasters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HtmlContentMasters_ImageMasters_ImageMasterId",
                        column: x => x.ImageMasterId,
                        principalTable: "ImageMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageDetails",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternateText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDetails", x => new { x.LanguageCode, x.ImageID });
                    table.ForeignKey(
                        name: "FK_ImageDetails_ImageMasters_ImageID",
                        column: x => x.ImageID,
                        principalTable: "ImageMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SucessStoryDetails",
                columns: table => new
                {
                    SucessStoryID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SucessStoryMasterID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucessStoryDetails", x => new { x.LanguageCode, x.SucessStoryID });
                    table.ForeignKey(
                        name: "FK_SucessStoryDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SucessStoryDetails_SucessStoryMasters_SucessStoryMasterID",
                        column: x => x.SucessStoryMasterID,
                        principalTable: "SucessStoryMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HtmlContentDetails",
                columns: table => new
                {
                    HtmlContentID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlContentDetails", x => new { x.LanguageCode, x.HtmlContentID });
                    table.ForeignKey(
                        name: "FK_HtmlContentDetails_HtmlContentMasters_HtmlContentID",
                        column: x => x.HtmlContentID,
                        principalTable: "HtmlContentMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HtmlContentDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HtmlContentDetails_HtmlContentID",
                table: "HtmlContentDetails",
                column: "HtmlContentID");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlContentMasters_ImageMasterId",
                table: "HtmlContentMasters",
                column: "ImageMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_ImageID",
                table: "ImageDetails",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_SucessStoryDetails_SucessStoryMasterID",
                table: "SucessStoryDetails",
                column: "SucessStoryMasterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HtmlContentDetails");

            migrationBuilder.DropTable(
                name: "ImageDetails");

            migrationBuilder.DropTable(
                name: "SucessStoryDetails");

            migrationBuilder.DropTable(
                name: "HtmlContentMasters");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "SucessStoryMasters");

            migrationBuilder.DropTable(
                name: "ImageMasters");
        }
    }
}
