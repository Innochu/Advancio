using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvansioIntLtd.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaystackCustomerCode",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Wallets");

            migrationBuilder.RenameColumn(
                name: "TransactionPin",
                table: "Wallets",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Wallets",
                newName: "TransactionPin");

            migrationBuilder.AddColumn<string>(
                name: "PaystackCustomerCode",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
