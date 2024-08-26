using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.v5.Migrations
{
    /// <inheritdoc />
    public partial class Created_Book_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "AppBooks");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "AppBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "AppBooks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Shelf",
                table: "AppBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "Shelf",
                table: "AppBooks");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "AppBooks",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
