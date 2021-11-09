using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class AddForignKeys3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HtmlContentMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CanBeDeletedByUser = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlContentMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SectionMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionMasters", x => x.ID);
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
                name: "HtmlContentDetails",
                columns: table => new
                {
                    HtmlContentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HtmlContentMasterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlContentDetails", x => x.HtmlContentID);
                    table.ForeignKey(
                        name: "FK_HtmlContentDetails_HtmlContentMasters_HtmlContentMasterID",
                        column: x => x.HtmlContentMasterID,
                        principalTable: "HtmlContentMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HtmlContentDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    table.ForeignKey(
                        name: "FK_ImageMasters_SectionMasters_SectionMasterID",
                        column: x => x.SectionMasterID,
                        principalTable: "SectionMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SectionMasterID = table.Column<int>(type: "int", nullable: false),
                    SectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SectionDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionDetails_SectionMasters_SectionMasterID",
                        column: x => x.SectionMasterID,
                        principalTable: "SectionMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SucessStoryDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SucessStoryMasterID = table.Column<int>(type: "int", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucessStoryDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SucessStoryDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SucessStoryDetails_SucessStoryMasters_SucessStoryMasterID",
                        column: x => x.SucessStoryMasterID,
                        principalTable: "SucessStoryMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImageMasterID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternateText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageDetails_ImageMasters_ImageMasterID",
                        column: x => x.ImageMasterID,
                        principalTable: "ImageMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HtmlContentDetails_HtmlContentMasterID",
                table: "HtmlContentDetails",
                column: "HtmlContentMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlContentDetails_LanguageCode",
                table: "HtmlContentDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_ImageMasterID",
                table: "ImageDetails",
                column: "ImageMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_LanguageCode",
                table: "ImageDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImageMasters_SectionMasterID",
                table: "ImageMasters",
                column: "SectionMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetails_LanguageCode",
                table: "SectionDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetails_SectionMasterID",
                table: "SectionDetails",
                column: "SectionMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_SucessStoryDetails_LanguageCode",
                table: "SucessStoryDetails",
                column: "LanguageCode");

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
                name: "SectionDetails");

            migrationBuilder.DropTable(
                name: "SucessStoryDetails");

            migrationBuilder.DropTable(
                name: "HtmlContentMasters");

            migrationBuilder.DropTable(
                name: "ImageMasters");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "SucessStoryMasters");

            migrationBuilder.DropTable(
                name: "SectionMasters");
        }
    }
}
