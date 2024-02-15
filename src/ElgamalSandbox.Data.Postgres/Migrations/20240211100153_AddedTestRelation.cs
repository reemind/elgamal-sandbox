using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class AddedTestRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_succeeded",
                schema: "public",
                table: "task_test_attempt_relation",
                newName: "result");

            migrationBuilder.AddColumn<long>(
                name: "task_id",
                schema: "public",
                table: "task_test",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "ix_task_test_task_id",
                schema: "public",
                table: "task_test",
                column: "task_id");

            migrationBuilder.AddForeignKey(
                name: "fk_task_test_task_descriptions_task_id",
                schema: "public",
                table: "task_test",
                column: "task_id",
                principalSchema: "public",
                principalTable: "task_descriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_task_test_task_descriptions_task_id",
                schema: "public",
                table: "task_test");

            migrationBuilder.DropIndex(
                name: "ix_task_test_task_id",
                schema: "public",
                table: "task_test");

            migrationBuilder.DropColumn(
                name: "task_id",
                schema: "public",
                table: "task_test");

            migrationBuilder.RenameColumn(
                name: "result",
                schema: "public",
                table: "task_test_attempt_relation",
                newName: "is_succeeded");
        }
    }
}
