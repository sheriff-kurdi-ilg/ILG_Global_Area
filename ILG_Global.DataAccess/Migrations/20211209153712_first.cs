using Microsoft.EntityFrameworkCore.Migrations;

namespace ILG_Global.DataAccess.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseProcessMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseProcessMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformationMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FontAwsomeIconCssClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    NavigationURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClickable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformationMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HtmlContentMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsHasTitle = table.Column<int>(type: "int", nullable: false),
                    IsHasSubTitle = table.Column<int>(type: "int", nullable: false),
                    IsHasSummary = table.Column<int>(type: "int", nullable: false),
                    IsHasDescription = table.Column<int>(type: "int", nullable: false),
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "NewsLetterSubscribes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetterSubscribes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OurServiceMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ImageMastersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServiceMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShareViaEmailSubscriber",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareViaEmailSubscriber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SucessStoryMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PDF_FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucessStoryMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaseProcessDetails",
                columns: table => new
                {
                    CaseProcessID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OurServiceID = table.Column<int>(type: "int", nullable: false),
                    TextLine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseProcessDetails", x => new { x.CaseProcessID, x.LanguageCode });
                    table.ForeignKey(
                        name: "FK_CaseProcessDetails_CaseProcessMasters_CaseProcessID",
                        column: x => x.CaseProcessID,
                        principalTable: "CaseProcessMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseProcessDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
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
                    table.PrimaryKey("PK_HtmlContentDetails", x => new { x.HtmlContentID, x.LanguageCode });
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

            migrationBuilder.CreateTable(
                name: "ImageMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HtmlContentMasterID = table.Column<int>(type: "int", nullable: true),
                    OurServiceMasterID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ImageMastersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageMasters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageMasters_HtmlContentMasters_HtmlContentMasterID",
                        column: x => x.HtmlContentMasterID,
                        principalTable: "HtmlContentMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageMasters_OurServiceMasters_ImageMastersId",
                        column: x => x.ImageMastersId,
                        principalTable: "OurServiceMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageMasters_OurServiceMasters_OurServiceMasterID",
                        column: x => x.OurServiceMasterID,
                        principalTable: "OurServiceMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    table.PrimaryKey("PK_OurServiceDetails", x => new { x.OurServiceID, x.LanguageCode });
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

            migrationBuilder.CreateTable(
                name: "SucessStoryDetails",
                columns: table => new
                {
                    SucessStoryID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucessStoryDetails", x => new { x.SucessStoryID, x.LanguageCode });
                    table.ForeignKey(
                        name: "FK_SucessStoryDetails_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SucessStoryDetails_SucessStoryMasters_SucessStoryID",
                        column: x => x.SucessStoryID,
                        principalTable: "SucessStoryMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageDetails",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternateText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurServiceMasterID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDetails", x => new { x.ImageID, x.LanguageCode });
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
                    table.ForeignKey(
                        name: "FK_ImageDetails_OurServiceMasters_OurServiceMasterID",
                        column: x => x.OurServiceMasterID,
                        principalTable: "OurServiceMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseProcessDetails_LanguageCode",
                table: "CaseProcessDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformationDetails_LanguageCode",
                table: "ContactInformationDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlContentDetails_LanguageCode",
                table: "HtmlContentDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_LanguageCode",
                table: "ImageDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_OurServiceMasterID",
                table: "ImageDetails",
                column: "OurServiceMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageMasters_HtmlContentMasterID",
                table: "ImageMasters",
                column: "HtmlContentMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageMasters_ImageMastersId",
                table: "ImageMasters",
                column: "ImageMastersId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageMasters_OurServiceMasterID",
                table: "ImageMasters",
                column: "OurServiceMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_OurServiceDetails_LanguageCode",
                table: "OurServiceDetails",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_SucessStoryDetails_LanguageCode",
                table: "SucessStoryDetails",
                column: "LanguageCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseProcessDetails");

            migrationBuilder.DropTable(
                name: "ContactInformationDetails");

            migrationBuilder.DropTable(
                name: "HtmlContentDetails");

            migrationBuilder.DropTable(
                name: "ImageDetails");

            migrationBuilder.DropTable(
                name: "NewsLetterSubscribes");

            migrationBuilder.DropTable(
                name: "OurServiceDetails");

            migrationBuilder.DropTable(
                name: "ShareViaEmailSubscriber");

            migrationBuilder.DropTable(
                name: "SucessStoryDetails");

            migrationBuilder.DropTable(
                name: "CaseProcessMasters");

            migrationBuilder.DropTable(
                name: "ContactInformationMasters");

            migrationBuilder.DropTable(
                name: "ImageMasters");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "SucessStoryMasters");

            migrationBuilder.DropTable(
                name: "HtmlContentMasters");

            migrationBuilder.DropTable(
                name: "OurServiceMasters");
        }
    }
}
