using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFGDevopsApp.Migrations
{
    /// <inheritdoc />
    public partial class IssueTraking8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChangeSetId",
                table: "IssueTrackings",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeSetId",
                table: "IssueTrackings");
        }
    }
}
