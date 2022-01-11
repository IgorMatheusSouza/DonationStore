using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationStore.Repository.Migrations.DonationStore
{
    public partial class AddressNumberProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressNumber",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressNumber",
                table: "Donations");
        }
    }
}
