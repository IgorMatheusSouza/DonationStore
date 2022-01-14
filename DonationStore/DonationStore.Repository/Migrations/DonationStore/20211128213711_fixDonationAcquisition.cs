using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationStore.Repository.Migrations.DonationStore
{
    public partial class fixDonationAcquisition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_DonationAcquisition_AspNetUsers_UserId1",
            //    table: "DonationAcquisition");

            //migrationBuilder.DropIndex(
            //    name: "IX_DonationAcquisition_UserId1",
            //    table: "DonationAcquisition");

            //migrationBuilder.DropColumn(
            //    name: "UserId1",
            //    table: "DonationAcquisition");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "DonationAcquisition",
            //    type: "nvarchar(450)",
            //    nullable: true,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DonationAcquisition_UserId",
            //    table: "DonationAcquisition",
            //    column: "UserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_DonationAcquisition_AspNetUsers_UserId",
            //    table: "DonationAcquisition",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationAcquisition_AspNetUsers_UserId",
                table: "DonationAcquisition");

            migrationBuilder.DropIndex(
                name: "IX_DonationAcquisition_UserId",
                table: "DonationAcquisition");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "DonationAcquisition",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "DonationAcquisition",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonationAcquisition_UserId1",
                table: "DonationAcquisition",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationAcquisition_AspNetUsers_UserId1",
                table: "DonationAcquisition",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
