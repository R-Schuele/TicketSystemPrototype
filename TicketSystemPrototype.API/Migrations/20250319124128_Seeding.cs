using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketSystemPrototype.API.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AssingedTo", "CreatedAt", "CreatedBy", "Description", "Name", "Priority", "Status" },
                values: new object[,]
                {
                    { 1, "Robin", new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), "Robin", "Read Tutorials and make a project", "Learn Blazor", 2, 1 },
                    { 2, "Robin", new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), "Robin", "Download EFCore NuGet Package and configure", "Implement Entity Framework Core", 1, 2 },
                    { 3, "Robin", new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), "Robin", "Download SQLite Browser and open generated Datebase file", "Implement SQLite Database with SQLite Browser", 1, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
