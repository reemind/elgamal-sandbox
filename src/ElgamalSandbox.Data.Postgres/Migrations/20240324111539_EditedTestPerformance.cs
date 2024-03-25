using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class EditedTestPerformance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_performance_test_task_descriptions_task_description_id",
                schema: "public",
                table: "performance_test");

            migrationBuilder.DropForeignKey(
                name: "fk_performance_test_attempt_performance_test_performance_test_id",
                schema: "public",
                table: "performance_test_attempt");

            migrationBuilder.DropPrimaryKey(
                name: "pk_performance_test",
                schema: "public",
                table: "performance_test");

            migrationBuilder.RenameTable(
                name: "performance_test",
                schema: "public",
                newName: "performance_tests",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "ix_performance_test_task_description_id",
                schema: "public",
                table: "performance_tests",
                newName: "ix_performance_tests_task_description_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "performance_tests",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "now()",
                comment: "Время изменения записи",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "performance_tests",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "now()",
                comment: "Время создания записи",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "pk_performance_tests",
                schema: "public",
                table: "performance_tests",
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

            migrationBuilder.AddForeignKey(
                name: "fk_performance_tests_task_descriptions_task_description_id",
                schema: "public",
                table: "performance_tests",
                column: "task_description_id",
                principalSchema: "public",
                principalTable: "task_descriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_performance_test_attempt_performance_tests_performance_test_id",
                schema: "public",
                table: "performance_test_attempt");

            migrationBuilder.DropForeignKey(
                name: "fk_performance_tests_task_descriptions_task_description_id",
                schema: "public",
                table: "performance_tests");

            migrationBuilder.DropPrimaryKey(
                name: "pk_performance_tests",
                schema: "public",
                table: "performance_tests");

            migrationBuilder.RenameTable(
                name: "performance_tests",
                schema: "public",
                newName: "performance_test",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "ix_performance_tests_task_description_id",
                schema: "public",
                table: "performance_test",
                newName: "ix_performance_test_task_description_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "performance_test",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "now()",
                oldComment: "Время изменения записи");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "performance_test",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "now()",
                oldComment: "Время создания записи");

            migrationBuilder.AddPrimaryKey(
                name: "pk_performance_test",
                schema: "public",
                table: "performance_test",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_performance_test_task_descriptions_task_description_id",
                schema: "public",
                table: "performance_test",
                column: "task_description_id",
                principalSchema: "public",
                principalTable: "task_descriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_performance_test_attempt_performance_test_performance_test_id",
                schema: "public",
                table: "performance_test_attempt",
                column: "performance_test_id",
                principalSchema: "public",
                principalTable: "performance_test",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
