using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAPIProject.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaTableWithnewdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 3, 7, 11, 10, 12, 580, DateTimeKind.Local).AddTicks(4173), "https://plus.unsplash.com/premium_photo-1709311441238-1c83ef3b8d04?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyfHx8ZW58MHx8fHx8" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details", "ImageUrl" },
                values: new object[] { new DateTime(2024, 3, 7, 11, 10, 12, 580, DateTimeKind.Local).AddTicks(4188), "hello this is me XYZ", "https://plus.unsplash.com/premium_photo-1709311441238-1c83ef3b8d04?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyfHx8ZW58MHx8fHx8" });

            migrationBuilder.InsertData(
                table: "villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[] { 3, "", new DateTime(2024, 3, 7, 11, 10, 12, 580, DateTimeKind.Local).AddTicks(4190), "hello this is me John", "https://plus.unsplash.com/premium_photo-1709311441238-1c83ef3b8d04?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyfHx8ZW58MHx8fHx8", "John", 400, 20000.0, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 3, 6, 18, 32, 29, 789, DateTimeKind.Local).AddTicks(6124), "" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details", "ImageUrl" },
                values: new object[] { new DateTime(2024, 3, 6, 18, 32, 29, 789, DateTimeKind.Local).AddTicks(6143), "hello this is me other", "" });
        }
    }
}
