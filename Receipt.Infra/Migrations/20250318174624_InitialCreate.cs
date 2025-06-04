using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Receipt.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteMaster_userMasters_UserId",
                table: "SiteMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteMaster",
                table: "SiteMaster");

            migrationBuilder.RenameTable(
                name: "SiteMaster",
                newName: "siteMasters");

            migrationBuilder.RenameIndex(
                name: "IX_SiteMaster_UserId",
                table: "siteMasters",
                newName: "IX_siteMasters_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_siteMasters",
                table: "siteMasters",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_siteMasters_userMasters_UserId",
                table: "siteMasters",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_siteMasters_userMasters_UserId",
                table: "siteMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_siteMasters",
                table: "siteMasters");

            migrationBuilder.RenameTable(
                name: "siteMasters",
                newName: "SiteMaster");

            migrationBuilder.RenameIndex(
                name: "IX_siteMasters_UserId",
                table: "SiteMaster",
                newName: "IX_SiteMaster_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteMaster",
                table: "SiteMaster",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteMaster_userMasters_UserId",
                table: "SiteMaster",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
