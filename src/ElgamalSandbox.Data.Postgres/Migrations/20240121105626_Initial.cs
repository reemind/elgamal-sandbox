using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "task_descriptions",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    toolbox = table.Column<string>(type: "TEXT", nullable: false),
                    input_vars = table.Column<string>(type: "TEXT", nullable: false),
                    output_vars = table.Column<string>(type: "TEXT", nullable: false),
                    number = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    playground = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "now()", comment: "Время создания записи"),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "now()", comment: "Время изменения записи")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_descriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_attempts",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(type: "TEXT", nullable: false),
                    playground = table.Column<string>(type: "TEXT", nullable: true),
                    parameters = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    is_succeeded = table.Column<bool>(type: "INTEGER", nullable: false),
                    task_description_id = table.Column<long>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "now()", comment: "Время создания записи"),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "now()", comment: "Время изменения записи")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_attempts", x => x.id);
                    table.ForeignKey(
                        name: "fk_task_attempts_task_descriptions_task_description_id",
                        column: x => x.task_description_id,
                        principalSchema: "public",
                        principalTable: "task_descriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_task_attempts_task_description_id",
                schema: "public",
                table: "task_attempts",
                column: "task_description_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task_attempts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "task_descriptions",
                schema: "public");
        }
    }
}
