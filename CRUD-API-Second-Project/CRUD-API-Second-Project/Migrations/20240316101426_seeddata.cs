using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_API_Second_Project.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Visible",
                table: "Posts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Content", "FeaturedImageUrl", "PublishDate", "Summary", "Title", "UpdateDate", "UrlHandle", "Visible" },
                values: new object[] { new Guid("a6b2e063-f834-416e-a3d3-196be16205af"), "BK", "This is content 1", "https://images.unsplash.com/photo-1706026803368-d84389566a80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw1fHx8ZW58MHx8fHx8", new DateTime(2024, 3, 16, 15, 44, 26, 325, DateTimeKind.Local).AddTicks(1194), "This is summary 1", "This is title 1", new DateTime(2024, 3, 16, 15, 44, 26, 325, DateTimeKind.Local).AddTicks(1206), "Yes", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a6b2e063-f834-416e-a3d3-196be16205af"));

            migrationBuilder.AlterColumn<string>(
                name: "Visible",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
