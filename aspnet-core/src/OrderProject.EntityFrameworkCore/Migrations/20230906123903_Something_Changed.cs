using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderProject.Migrations
{
    /// <inheritdoc />
    public partial class SomethingChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppCustomers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppCustomers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppCustomers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppCustomers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppCustomers",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppCustomers");
        }
    }
}
