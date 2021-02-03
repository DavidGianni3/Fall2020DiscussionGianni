using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppGianni.Data.Migrations
{
    public partial class AddedFundForVoucherCriteriaAndFundAndModVoucherRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundCriteria",
                columns: table => new
                {
                    FundCriteriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundID = table.Column<int>(nullable: false),
                    ClientLocation = table.Column<string>(nullable: true),
                    PetGender = table.Column<string>(nullable: true),
                    PetSize = table.Column<string>(nullable: true),
                    PetType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundCriteria", x => x.FundCriteriaID);
                });

            migrationBuilder.CreateTable(
                name: "Fund",
                columns: table => new
                {
                    FundID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundName = table.Column<string>(nullable: false),
                    FundType = table.Column<string>(nullable: true),
                    OriginalFundAmount = table.Column<double>(nullable: true),
                    CurrentFundAmount = table.Column<double>(nullable: true),
                    FundCriteriaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fund", x => x.FundID);
                    table.ForeignKey(
                        name: "FK_Fund_FundCriteria_FundCriteriaID",
                        column: x => x.FundCriteriaID,
                        principalTable: "FundCriteria",
                        principalColumn: "FundCriteriaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundForVoucher",
                columns: table => new
                {
                    FundForVoucherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountAssigned = table.Column<double>(nullable: false),
                    RequestID = table.Column<int>(nullable: false),
                    FundID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundForVoucher", x => x.FundForVoucherID);
                    table.ForeignKey(
                        name: "FK_FundForVoucher_Fund_FundID",
                        column: x => x.FundID,
                        principalTable: "Fund",
                        principalColumn: "FundID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundForVoucher_VoucherRequest_RequestID",
                        column: x => x.RequestID,
                        principalTable: "VoucherRequest",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fund_FundCriteriaID",
                table: "Fund",
                column: "FundCriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_FundCriteria_FundID",
                table: "FundCriteria",
                column: "FundID");

            migrationBuilder.CreateIndex(
                name: "IX_FundForVoucher_FundID",
                table: "FundForVoucher",
                column: "FundID");

            migrationBuilder.CreateIndex(
                name: "IX_FundForVoucher_RequestID",
                table: "FundForVoucher",
                column: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_FundCriteria_Fund_FundID",
                table: "FundCriteria",
                column: "FundID",
                principalTable: "Fund",
                principalColumn: "FundID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fund_FundCriteria_FundCriteriaID",
                table: "Fund");

            migrationBuilder.DropTable(
                name: "FundForVoucher");

            migrationBuilder.DropTable(
                name: "FundCriteria");

            migrationBuilder.DropTable(
                name: "Fund");
        }
    }
}
