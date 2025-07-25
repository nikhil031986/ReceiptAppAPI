using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Receipt.Infra.Migrations
{
    /// <inheritdoc />
    public partial class updateV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbwingMasters_userMasters_UserId",
                table: "DbwingMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_receiptDetails_userMasters_UserId",
                table: "receiptDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_siteMasters_userMasters_UserId",
                table: "siteMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_wingDetails_userMasters_UserId",
                table: "wingDetails");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "userMasters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "customerMasters");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "wingDetails",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "wingDetails",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "receiptDetails",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "receiptDetails",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "DbwingMasters",
                newName: "UpdateuserId");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "DbwingMasters",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "customerMasters",
                newName: "UpdateuserId");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "customerMasters",
                newName: "UpdatedAt");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "wingDetails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "wingDetails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AddColumn<int>(
                name: "CreateuserId",
                table: "wingDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateuserId",
                table: "wingDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "userMasters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "userMasters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateuserId",
                table: "userMasters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedAt",
                table: "userMasters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateuserId",
                table: "userMasters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "siteMasters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "siteMasters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateuserId",
                table: "siteMasters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "siteMasters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedAt",
                table: "siteMasters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateuserId",
                table: "siteMasters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "receiptDetails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPrint",
                table: "receiptDetails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCancel",
                table: "receiptDetails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "receiptDetails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AddColumn<int>(
                name: "CreateuserId",
                table: "receiptDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateuserId",
                table: "receiptDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DbwingMasters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "DbwingMasters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "DbwingMasters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateuserId",
                table: "DbwingMasters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsBanakhat",
                table: "customerMasters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "customerMasters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "customerMasters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateuserId",
                table: "customerMasters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMain",
                table: "customerDetails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "customerDetails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "customerDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateuserId",
                table: "customerDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedAt",
                table: "customerDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateuserId",
                table: "customerDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DbwingMasters_userMasters_UserId",
                table: "DbwingMasters",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_receiptDetails_userMasters_UserId",
                table: "receiptDetails",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_siteMasters_userMasters_UserId",
                table: "siteMasters",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_wingDetails_userMasters_UserId",
                table: "wingDetails",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbwingMasters_userMasters_UserId",
                table: "DbwingMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_receiptDetails_userMasters_UserId",
                table: "receiptDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_siteMasters_userMasters_UserId",
                table: "siteMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_wingDetails_userMasters_UserId",
                table: "wingDetails");

            migrationBuilder.DropColumn(
                name: "CreateuserId",
                table: "wingDetails");

            migrationBuilder.DropColumn(
                name: "UpdateuserId",
                table: "wingDetails");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "userMasters");

            migrationBuilder.DropColumn(
                name: "CreateuserId",
                table: "userMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "userMasters");

            migrationBuilder.DropColumn(
                name: "UpdateuserId",
                table: "userMasters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "siteMasters");

            migrationBuilder.DropColumn(
                name: "CreateuserId",
                table: "siteMasters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "siteMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "siteMasters");

            migrationBuilder.DropColumn(
                name: "UpdateuserId",
                table: "siteMasters");

            migrationBuilder.DropColumn(
                name: "CreateuserId",
                table: "receiptDetails");

            migrationBuilder.DropColumn(
                name: "UpdateuserId",
                table: "receiptDetails");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DbwingMasters");

            migrationBuilder.DropColumn(
                name: "CreateuserId",
                table: "DbwingMasters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "customerMasters");

            migrationBuilder.DropColumn(
                name: "CreateuserId",
                table: "customerMasters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "customerDetails");

            migrationBuilder.DropColumn(
                name: "CreateuserId",
                table: "customerDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "customerDetails");

            migrationBuilder.DropColumn(
                name: "UpdateuserId",
                table: "customerDetails");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "wingDetails",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "wingDetails",
                newName: "EntryDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "receiptDetails",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "receiptDetails",
                newName: "EntryDate");

            migrationBuilder.RenameColumn(
                name: "UpdateuserId",
                table: "DbwingMasters",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "DbwingMasters",
                newName: "EntryDate");

            migrationBuilder.RenameColumn(
                name: "UpdateuserId",
                table: "customerMasters",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "customerMasters",
                newName: "EntryDate");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "wingDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "IsActive",
                table: "wingDetails",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "userMasters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateDate",
                table: "userMasters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "siteMasters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "receiptDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "IsPrint",
                table: "receiptDetails",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "IsCancel",
                table: "receiptDetails",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "IsActive",
                table: "receiptDetails",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DbwingMasters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "IsActive",
                table: "DbwingMasters",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "IsBanakhat",
                table: "customerMasters",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                table: "customerMasters",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "customerMasters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "IsMain",
                table: "customerDetails",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "IsActive",
                table: "customerDetails",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DbwingMasters_userMasters_UserId",
                table: "DbwingMasters",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_receiptDetails_userMasters_UserId",
                table: "receiptDetails",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_siteMasters_userMasters_UserId",
                table: "siteMasters",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wingDetails_userMasters_UserId",
                table: "wingDetails",
                column: "UserId",
                principalTable: "userMasters",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
