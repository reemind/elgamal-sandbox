using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class EditedTestPerformance3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "input_values",
                schema: "public",
                table: "performance_test_attempt");

            migrationBuilder.DropColumn(
                name: "task_description_id",
                schema: "public",
                table: "performance_test_attempt");

            migrationBuilder.RenameColumn(
                name: "times",
                schema: "public",
                table: "performance_test_attempt",
                newName: "runs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "performance_test_attempt",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "now()",
                comment: "Время изменения записи",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "performance_test_attempt",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "now()",
                comment: "Время создания записи",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "runs",
                schema: "public",
                table: "performance_test_attempt",
                newName: "times");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "performance_test_attempt",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "now()",
                oldComment: "Время изменения записи");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "performance_test_attempt",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "now()",
                oldComment: "Время создания записи");

            migrationBuilder.AddColumn<string>(
                name: "input_values",
                schema: "public",
                table: "performance_test_attempt",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "task_description_id",
                schema: "public",
                table: "performance_test_attempt",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
