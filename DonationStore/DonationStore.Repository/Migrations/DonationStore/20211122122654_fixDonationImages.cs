using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationStore.Repository.Migrations.DonationStore
{
    public partial class fixDonationImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationImages_Donations_UserId",
                table: "DonationImages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DonationImages",
                newName: "DonationId");

            migrationBuilder.RenameIndex(
                name: "IX_DonationImages_UserId",
                table: "DonationImages",
                newName: "IX_DonationImages_DonationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationImages_Donations_DonationId",
                table: "DonationImages",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationImages_Donations_DonationId",
                table: "DonationImages");

            migrationBuilder.RenameColumn(
                name: "DonationId",
                table: "DonationImages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DonationImages_DonationId",
                table: "DonationImages",
                newName: "IX_DonationImages_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationImages_Donations_UserId",
                table: "DonationImages",
                column: "UserId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
