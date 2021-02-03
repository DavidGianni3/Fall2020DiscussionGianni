using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppGianni.Data.Migrations
{
    public partial class AddeRequestDecisionDateToVoucherRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDecisionDate",
                table: "VoucherRequest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestDecisionDate",
                table: "VoucherRequest");
        }
    }
}
