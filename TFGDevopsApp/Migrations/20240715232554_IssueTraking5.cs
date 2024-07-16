using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFGDevopsApp.Migrations
{
    /// <inheritdoc />
    public partial class IssueTraking5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifieddBy",
                table: "IssueTrackings",
                newName: "ModifiedBy");

            migrationBuilder.AlterColumn<string>(
                name: "Reporter",
                table: "IssueTrackings",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "IssueTrackings",
                newName: "ModifieddBy");

            migrationBuilder.AlterColumn<string>(
                name: "Reporter",
                table: "IssueTrackings",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
