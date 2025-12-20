using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Receipt.Infra.Migrations.UserSiteTableUpdate
{
    /// <inheritdoc />
    public partial class UserSiteTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "userSites",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "userSites");
        }
    }
}
