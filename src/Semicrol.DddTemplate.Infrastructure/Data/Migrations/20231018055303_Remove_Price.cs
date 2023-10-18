using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Semicrol.DddTemplate.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
