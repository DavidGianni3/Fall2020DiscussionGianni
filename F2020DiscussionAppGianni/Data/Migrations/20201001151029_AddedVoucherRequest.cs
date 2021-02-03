using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppGianni.Data.Migrations
{
    public partial class AddedVoucherRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoucherRequest",
                columns: table => new
                {
                    RequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    RequestStatus = table.Column<string>(nullable: false),
                    PetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherRequest", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_VoucherRequest_Pet_PetID",
                        column: x => x.PetID,
                        principalTable: "Pet",
                        principalColumn: "PetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoucherRequest_PetID",
                table: "VoucherRequest",
                column: "PetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoucherRequest");
        }
    }
}
