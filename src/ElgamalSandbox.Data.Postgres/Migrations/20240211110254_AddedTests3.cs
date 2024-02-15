using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class AddedTests3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_task_test_attempt_relation_task_attempts_attempt_id",
                schema: "public",
                table: "task_test_attempt_relation");

            migrationBuilder.DropForeignKey(
                name: "fk_task_test_attempt_relation_task_test_test_id",
                schema: "public",
                table: "task_test_attempt_relation");

            migrationBuilder.CreateIndex(
                name: "ix_task_test_attempt_relation_test_id",
                schema: "public",
                table: "task_test_attempt_relation",
                column: "test_id");

            migrationBuilder.AddForeignKey(
                name: "fk_task_test_attempt_relation_task_attempts_attempt_id",
                schema: "public",
                table: "task_test_attempt_relation",
                column: "test_id",
                principalSchema: "public",
                principalTable: "task_attempts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_task_test_attempt_relation_task_test_test_id",
                schema: "public",
                table: "task_test_attempt_relation",
                column: "test_id",
                principalSchema: "public",
                principalTable: "task_test",
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

            migrationBuilder.DropForeignKey(
                name: "fk_task_test_attempt_relation_task_test_test_id",
                schema: "public",
                table: "task_test_attempt_relation");

            migrationBuilder.DropIndex(
                name: "ix_task_test_attempt_relation_test_id",
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

            migrationBuilder.AddForeignKey(
                name: "fk_task_test_attempt_relation_task_test_test_id",
                schema: "public",
                table: "task_test_attempt_relation",
                column: "attempt_id",
                principalSchema: "public",
                principalTable: "task_test",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
