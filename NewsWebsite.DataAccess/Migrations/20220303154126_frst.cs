using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebsite.Data.Migrations
{
    public partial class frst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    ShareCount = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DislikeCount = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsPosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsPosts_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    NewsPostId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_NewsPosts_NewsPostId",
                        column: x => x.NewsPostId,
                        principalTable: "NewsPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 693, DateTimeKind.Local).AddTicks(4511), "The opinion and analysis of global politics.", true, false, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 693, DateTimeKind.Local).AddTicks(4521), "Politics" },
                    { 2, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 693, DateTimeKind.Local).AddTicks(4538), "The latest health news and read articles on fitness, diet, nutrition, parenting, medicine, and diseases.", true, false, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 693, DateTimeKind.Local).AddTicks(4540), "Health" },
                    { 3, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 693, DateTimeKind.Local).AddTicks(4544), "The Latest sports news, scores, schedules, stats and more.", true, false, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 693, DateTimeKind.Local).AddTicks(4545), "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 698, DateTimeKind.Local).AddTicks(5397), true, false, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 698, DateTimeKind.Local).AddTicks(5406), "English" },
                    { 2, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 698, DateTimeKind.Local).AddTicks(5415), true, false, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 698, DateTimeKind.Local).AddTicks(5416), "Turkish" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 700, DateTimeKind.Local).AddTicks(777), "Admin rolü tüm haklara sahiptir.", true, false, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 700, DateTimeKind.Local).AddTicks(789), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "PasswordHash", "Picture", "RoleId", "UserName" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 711, DateTimeKind.Local).AddTicks(3275), "btuglu@", "Büşra", true, false, "Tuğlu", "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 711, DateTimeKind.Local).AddTicks(3289), new byte[] { 55, 52, 56, 56, 101, 51, 51, 49, 98, 56, 98, 54, 52, 101, 53, 55, 57, 52, 100, 97, 51, 102, 97, 52, 101, 98, 49, 48, 97, 100, 53, 100 }, "https://www.pngkey.com/png/full/151-1518198_avatar-anonimo-mujer-women-user-icon-png.png", 1, "btuglu" });

            migrationBuilder.InsertData(
                table: "NewsPosts",
                columns: new[] { "Id", "Author", "AuthorDescription", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "DislikeCount", "IsActive", "IsDeleted", "LanguageId", "LikeCount", "ModifiedByName", "ModifiedDate", "ShareCount", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 1, "Büşra Tuğlu", "The author is interested in politics, health, and sports.", 1, 156, "Russian tennis player Andrey Rublev has appealed for peace between Russia and Ukraine by signing a camera lens with a 'no war please' message, after getting through to the final of the Dubai Tennis Championship.", "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 690, DateTimeKind.Local).AddTicks(4930), new DateTime(2022, 3, 3, 18, 41, 25, 690, DateTimeKind.Local).AddTicks(4125), 274, true, false, 1, 1463, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 690, DateTimeKind.Local).AddTicks(5212), 355, "Default.jpg", "No War in Ukraine", 1, 3500 });

            migrationBuilder.InsertData(
                table: "NewsPosts",
                columns: new[] { "Id", "Author", "AuthorDescription", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "DislikeCount", "IsActive", "IsDeleted", "LanguageId", "LikeCount", "ModifiedByName", "ModifiedDate", "ShareCount", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 2, "Büşra Tuğlu", "The author is interested in politics, health, and sports.", 2, 302, "Many of my clients who work away from home have one common obstacle: they don't plan ahead when it comes to lunch. As a result, they typically wind up eating something—like a fast-food hamburger.", "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 690, DateTimeKind.Local).AddTicks(7054), new DateTime(2022, 3, 3, 18, 41, 25, 690, DateTimeKind.Local).AddTicks(7052), 484, true, false, 1, 2600, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 690, DateTimeKind.Local).AddTicks(7055), 795, "Default.jpg", "5 Healthy and Easy Lunch Ideas for Work", 1, 5000 });

            migrationBuilder.InsertData(
                table: "NewsPosts",
                columns: new[] { "Id", "Author", "AuthorDescription", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "DislikeCount", "IsActive", "IsDeleted", "LanguageId", "LikeCount", "ModifiedByName", "ModifiedDate", "ShareCount", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 3, "Büşra Tuğlu", "The author is interested in politics, health, and sports.", 3, 5, "Süper Lig'de lider konumda bulunan Trabzonspor'da, şehri şampiyonluk havası sardı. En yakın rakibi Konyaspor ile aradaki puan farkını yükselten Trabzon'da Faroz civarında bulunan trafik ışıklarına kupa görseli yansıtıldı.", "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 690, DateTimeKind.Local).AddTicks(7062), new DateTime(2022, 3, 3, 18, 41, 25, 690, DateTimeKind.Local).AddTicks(7061), 3, true, false, 2, 19, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 690, DateTimeKind.Local).AddTicks(7063), 57, "Default.jpg", "Trabzon'da Trafik Lambaları da Şampiyonluk İstiyor: 'O Sene, Bu Sene", 1, 706 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "LanguageId", "ModifiedByName", "ModifiedDate", "NewsPostId", "Text" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 695, DateTimeKind.Local).AddTicks(6453), true, false, 1, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 695, DateTimeKind.Local).AddTicks(6462), 1, "No war, stop war!" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "LanguageId", "ModifiedByName", "ModifiedDate", "NewsPostId", "Text" },
                values: new object[] { 2, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 695, DateTimeKind.Local).AddTicks(6477), true, false, 1, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 695, DateTimeKind.Local).AddTicks(6478), 2, "These are good advice, I hope I can apply them." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "LanguageId", "ModifiedByName", "ModifiedDate", "NewsPostId", "Text" },
                values: new object[] { 3, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 695, DateTimeKind.Local).AddTicks(6482), true, false, 2, "InitialCreate", new DateTime(2022, 3, 3, 18, 41, 25, 695, DateTimeKind.Local).AddTicks(6483), 3, "Bu sene o sene mi, göreceğiz." });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LanguageId",
                table: "Comments",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsPostId",
                table: "Comments",
                column: "NewsPostId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPosts_CategoryId",
                table: "NewsPosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPosts_LanguageId",
                table: "NewsPosts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPosts_UserId",
                table: "NewsPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "NewsPosts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
