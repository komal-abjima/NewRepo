using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Website.Migrations
{
    /// <inheritdoc />
    public partial class addcategorycolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "products");
        }
    }
}
