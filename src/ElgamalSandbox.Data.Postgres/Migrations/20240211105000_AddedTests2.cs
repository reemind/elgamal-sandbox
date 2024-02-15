using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class AddedTests2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "parameters",
                schema: "public",
                table: "task_attempts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "parameters",
                schema: "public",
                table: "task_attempts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
