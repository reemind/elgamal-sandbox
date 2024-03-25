using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class EditedTestPerformance4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_performance_test_attempt_performance_tests_performance_test_id",
                schema: "public",
                table: "performance_test_attempt");

            migrationBuilder.DropPrimaryKey(
                name: "pk_performance_test_attempt",
                schema: "public",
                table: "performance_test_attempt");

            migrationBuilder.RenameTable(
                name: "performance_test_attempt",
                schema: "public",
                newName: "performance_test_attempts",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "ix_performance_test_attempt_performance_test_id",
                schema: "public",
                table: "performance_test_attempts",
                newName: "ix_performance_test_attempts_performance_test_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_performance_test_attempts",
                schema: "public",
                table: "performance_test_attempts",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_performance_test_attempts_performance_tests_performance_test_id",
                schema: "public",
                table: "performance_test_attempts",
                column: "performance_test_id",
                principalSchema: "public",
                principalTable: "performance_tests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_performance_test_attempts_performance_tests_performance_test_id",
                schema: "public",
                table: "performance_test_attempts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_performance_test_attempts",
                schema: "public",
                table: "performance_test_attempts");

            migrationBuilder.RenameTable(
                name: "performance_test_attempts",
                schema: "public",
                newName: "performance_test_attempt",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "ix_performance_test_attempts_performance_test_id",
                schema: "public",
                table: "performance_test_attempt",
                newName: "ix_performance_test_attempt_performance_test_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_performance_test_attempt",
                schema: "public",
                table: "performance_test_attempt",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_performance_test_attempt_performance_tests_performance_test_id",
                schema: "public",
                table: "performance_test_attempt",
                column: "performance_test_id",
                principalSchema: "public",
                principalTable: "performance_tests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
