using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppGianni.Data.Migrations
{
    public partial class ModifiedVoucherRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RequestAmount",
                table: "VoucherRequest",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VoucherRedeemed",
                table: "VoucherRequest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestAmount",
                table: "VoucherRequest");

            migrationBuilder.DropColumn(
                name: "VoucherRedeemed",
                table: "VoucherRequest");
        }
    }
}
