using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFGDevopsApp.Migrations
{
    /// <inheritdoc />
    public partial class IssueTraking2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "IssueTrackings",
                newName: "Summary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "IssueTrackings",
                newName: "Resume");
        }
    }
}
