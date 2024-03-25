using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class AddedTestPerformance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "performance_tests",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    task_description_id = table.Column<long>(type: "INTEGER", nullable: false),
                    prepare_script = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_performance_test", x => x.id);
                    table.ForeignKey(
                        name: "fk_performance_test_task_descriptions_task_description_id",
                        column: x => x.task_description_id,
                        principalSchema: "public",
                        principalTable: "task_descriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "performance_test_attempt",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    times = table.Column<string>(type: "TEXT", nullable: false),
                    input_values = table.Column<string>(type: "TEXT", nullable: false),
                    task_description_id = table.Column<long>(type: "INTEGER", nullable: false),
                    performance_test_id = table.Column<long>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_performance_test_attempt", x => x.id);
                    table.ForeignKey(
                        name: "fk_performance_test_attempt_performance_test_performance_test_id",
                        column: x => x.performance_test_id,
                        principalSchema: "public",
                        principalTable: "performance_test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_performance_test_task_description_id",
                schema: "public",
                table: "performance_test",
                column: "task_description_id");

            migrationBuilder.CreateIndex(
                name: "ix_performance_test_attempt_performance_test_id",
                schema: "public",
                table: "performance_test_attempt",
                column: "performance_test_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "performance_test_attempt",
                schema: "public");

            migrationBuilder.DropTable(
                name: "performance_test",
                schema: "public");
        }
    }
}
