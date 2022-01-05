using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationStore.Repository.Migrations.DonationStore
{
    public partial class Geocoding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Donations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Donations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Donations");
        }
    }
}
