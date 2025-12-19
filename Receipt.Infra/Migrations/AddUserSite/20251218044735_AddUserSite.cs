using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Receipt.Infra.Migrations.AddUserSite
{
    /// <inheritdoc />
    public partial class AddUserSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userSites",
                columns: table => new
                {
                    UserSiteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    SiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateuserId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateuserId = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedAt = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userSites", x => x.UserSiteId);
                    table.ForeignKey(
                        name: "FK_userSites_siteMasters_SiteId",
                        column: x => x.SiteId,
                        principalTable: "siteMasters",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userSites_userMasters_UserId",
                        column: x => x.UserId,
                        principalTable: "userMasters",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userSites_SiteId",
                table: "userSites",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_userSites_UserId",
                table: "userSites",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userSites");
        }
    }
}
