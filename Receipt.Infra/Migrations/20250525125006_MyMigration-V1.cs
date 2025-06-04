using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Receipt.Infra.Migrations
{
    /// <inheritdoc />
    public partial class MyMigrationV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbwingMasters",
                columns: table => new
                {
                    WingMasterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    FloarCount = table.Column<int>(type: "INTEGER", nullable: true),
                    HouseCount = table.Column<int>(type: "INTEGER", nullable: true),
                    StartNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    EndNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    SiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    EntryDate = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbwingMasters", x => x.WingMasterId);
                    table.ForeignKey(
                        name: "FK_DbwingMasters_siteMasters_SiteId",
                        column: x => x.SiteId,
                        principalTable: "siteMasters",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbwingMasters_userMasters_UserId",
                        column: x => x.UserId,
                        principalTable: "userMasters",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wingDetails",
                columns: table => new
                {
                    WingDetailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WingMasterId = table.Column<int>(type: "INTEGER", nullable: true),
                    FlatNo = table.Column<string>(type: "TEXT", nullable: false),
                    WingName = table.Column<string>(type: "TEXT", nullable: false),
                    Land = table.Column<double>(type: "REAL", nullable: true),
                    Carpate = table.Column<double>(type: "REAL", nullable: true),
                    Wb = table.Column<double>(type: "REAL", nullable: true),
                    Total = table.Column<double>(type: "REAL", nullable: true),
                    Amount = table.Column<double>(type: "REAL", nullable: true),
                    East = table.Column<string>(type: "TEXT", nullable: true),
                    West = table.Column<string>(type: "TEXT", nullable: true),
                    North = table.Column<string>(type: "TEXT", nullable: true),
                    South = table.Column<string>(type: "TEXT", nullable: true),
                    FlowrName = table.Column<string>(type: "TEXT", nullable: true),
                    OpenTarrace = table.Column<double>(type: "REAL", nullable: true),
                    SiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    EntryDate = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wingDetails", x => x.WingDetailId);
                    table.ForeignKey(
                        name: "FK_wingDetails_DbwingMasters_WingMasterId",
                        column: x => x.WingMasterId,
                        principalTable: "DbwingMasters",
                        principalColumn: "WingMasterId");
                    table.ForeignKey(
                        name: "FK_wingDetails_siteMasters_SiteId",
                        column: x => x.SiteId,
                        principalTable: "siteMasters",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_wingDetails_userMasters_UserId",
                        column: x => x.UserId,
                        principalTable: "userMasters",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customerMasters",
                columns: table => new
                {
                    CustomerMasterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WingMasterId = table.Column<int>(type: "INTEGER", nullable: false),
                    WingDetailId = table.Column<int>(type: "INTEGER", nullable: false),
                    SiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsBanakhat = table.Column<byte[]>(type: "BLOB", nullable: true),
                    BanakhatNumber = table.Column<string>(type: "TEXT", nullable: true),
                    BanakhatDate = table.Column<string>(type: "TEXT", nullable: true),
                    FinacialName = table.Column<string>(type: "TEXT", nullable: true),
                    DastavgNo = table.Column<string>(type: "TEXT", nullable: true),
                    DastavgDate = table.Column<string>(type: "TEXT", nullable: true),
                    EntryDate = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerMasters", x => x.CustomerMasterId);
                    table.ForeignKey(
                        name: "FK_customerMasters_DbwingMasters_WingMasterId",
                        column: x => x.WingMasterId,
                        principalTable: "DbwingMasters",
                        principalColumn: "WingMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customerMasters_siteMasters_SiteId",
                        column: x => x.SiteId,
                        principalTable: "siteMasters",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customerMasters_wingDetails_WingDetailId",
                        column: x => x.WingDetailId,
                        principalTable: "wingDetails",
                        principalColumn: "WingDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customerDetails",
                columns: table => new
                {
                    CustomerDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    ContDetails = table.Column<string>(type: "TEXT", nullable: true),
                    PanNumber = table.Column<string>(type: "TEXT", nullable: true),
                    AadharNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Religin = table.Column<string>(type: "TEXT", nullable: true),
                    Ocupation = table.Column<string>(type: "TEXT", nullable: true),
                    ContactNumber = table.Column<string>(type: "TEXT", nullable: true),
                    EmaiId = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<byte[]>(type: "BLOB", nullable: true),
                    SiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerDetails", x => x.CustomerDetailsId);
                    table.ForeignKey(
                        name: "FK_customerDetails_customerMasters_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customerMasters",
                        principalColumn: "CustomerMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customerDetails_siteMasters_SiteId",
                        column: x => x.SiteId,
                        principalTable: "siteMasters",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receiptDetails",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceiptNo = table.Column<string>(type: "TEXT", nullable: true),
                    ReceiptDate = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    WingDetailId = table.Column<int>(type: "INTEGER", nullable: false),
                    WingMasterId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheqNeftRtgsNo = table.Column<string>(type: "TEXT", nullable: true),
                    BankName = table.Column<string>(type: "TEXT", nullable: true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: true),
                    ReceivedAs = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<double>(type: "REAL", nullable: true),
                    AmountInWord = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    EntryDate = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentDate = table.Column<string>(type: "TEXT", nullable: true),
                    IsCancel = table.Column<byte[]>(type: "BLOB", nullable: true),
                    IsPrint = table.Column<byte[]>(type: "BLOB", nullable: true),
                    SiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receiptDetails", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_receiptDetails_DbwingMasters_WingMasterId",
                        column: x => x.WingMasterId,
                        principalTable: "DbwingMasters",
                        principalColumn: "WingMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receiptDetails_customerMasters_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customerMasters",
                        principalColumn: "CustomerMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receiptDetails_userMasters_UserId",
                        column: x => x.UserId,
                        principalTable: "userMasters",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receiptDetails_wingDetails_WingDetailId",
                        column: x => x.WingDetailId,
                        principalTable: "wingDetails",
                        principalColumn: "WingDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customerDetails_CustomerId",
                table: "customerDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customerDetails_SiteId",
                table: "customerDetails",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_customerMasters_SiteId",
                table: "customerMasters",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_customerMasters_WingDetailId",
                table: "customerMasters",
                column: "WingDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_customerMasters_WingMasterId",
                table: "customerMasters",
                column: "WingMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DbwingMasters_SiteId",
                table: "DbwingMasters",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_DbwingMasters_UserId",
                table: "DbwingMasters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_receiptDetails_CustomerId",
                table: "receiptDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_receiptDetails_UserId",
                table: "receiptDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_receiptDetails_WingDetailId",
                table: "receiptDetails",
                column: "WingDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_receiptDetails_WingMasterId",
                table: "receiptDetails",
                column: "WingMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_wingDetails_SiteId",
                table: "wingDetails",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_wingDetails_UserId",
                table: "wingDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_wingDetails_WingMasterId",
                table: "wingDetails",
                column: "WingMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerDetails");

            migrationBuilder.DropTable(
                name: "receiptDetails");

            migrationBuilder.DropTable(
                name: "customerMasters");

            migrationBuilder.DropTable(
                name: "wingDetails");

            migrationBuilder.DropTable(
                name: "DbwingMasters");
        }
    }
}
