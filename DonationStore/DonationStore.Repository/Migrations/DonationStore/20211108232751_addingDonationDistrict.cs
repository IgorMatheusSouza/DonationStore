using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationStore.Repository.Migrations.DonationStore
{
    public partial class addingDonationDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Users_UserId1",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_UserId1",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_UserId",
                table: "Donations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Users_UserId",
                table: "Donations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Users_UserId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_UserId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Donations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Donations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_UserId1",
                table: "Donations",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Users_UserId1",
                table: "Donations",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
