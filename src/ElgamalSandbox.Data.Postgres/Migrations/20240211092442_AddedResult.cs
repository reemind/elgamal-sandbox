using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class AddedResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "result",
                schema: "public",
                table: "task_attempts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "task_test",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "now()", comment: "Время создания записи"),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "now()", comment: "Время изменения записи")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_test", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_test_attempt_relation",
                schema: "public",
                columns: table => new
                {
                    test_id = table.Column<long>(type: "INTEGER", nullable: false),
                    attempt_id = table.Column<long>(type: "INTEGER", nullable: false),
                    is_succeeded = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_test_attempt_relation", x => new { x.attempt_id, x.test_id });
                    table.ForeignKey(
                        name: "fk_task_test_attempt_relation_task_attempts_attempt_id",
                        column: x => x.attempt_id,
                        principalSchema: "public",
                        principalTable: "task_attempts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_task_test_attempt_relation_task_test_test_id",
                        column: x => x.attempt_id,
                        principalSchema: "public",
                        principalTable: "task_test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task_test_attempt_relation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "task_test",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "result",
                schema: "public",
                table: "task_attempts");
        }
    }
}
