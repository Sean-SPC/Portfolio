using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class GitHubRepoFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Project",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Project",
                newName: "HTML_URL");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Project",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Project",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Project",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Project",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "HTML_URL",
                table: "Project",
                newName: "ProjectName");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Project",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
