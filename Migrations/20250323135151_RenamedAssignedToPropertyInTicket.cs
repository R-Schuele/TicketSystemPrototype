using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystemPrototype.Migrations
{
    /// <inheritdoc />
    public partial class RenamedAssignedToPropertyInTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssingedTo",
                table: "Tickets",
                newName: "AssignedTo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssignedTo",
                table: "Tickets",
                newName: "AssingedTo");
        }
    }
}
