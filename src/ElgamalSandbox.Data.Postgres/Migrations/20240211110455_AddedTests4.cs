using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class AddedTests4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_task_test_attempt_relation_task_attempts_attempt_id",
                schema: "public",
                table: "task_test_attempt_relation");

            migrationBuilder.AddForeignKey(
                name: "fk_task_test_attempt_relation_task_attempts_attempt_id",
                schema: "public",
                table: "task_test_attempt_relation",
                column: "attempt_id",
                principalSchema: "public",
                principalTable: "task_attempts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_task_test_attempt_relation_task_attempts_attempt_id",
                schema: "public",
                table: "task_test_attempt_relation");

            migrationBuilder.AddForeignKey(
                name: "fk_task_test_attempt_relation_task_attempts_attempt_id",
                schema: "public",
                table: "task_test_attempt_relation",
                column: "test_id",
                principalSchema: "public",
                principalTable: "task_attempts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
