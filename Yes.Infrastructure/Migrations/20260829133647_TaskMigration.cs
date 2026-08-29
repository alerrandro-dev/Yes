using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yes.Infrastructure.Migrations;

/// <inheritdoc />
public partial class _20260829133647_TaskMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Tasks",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                ToDoListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tasks", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tasks_ToDoLists_ToDoListId",
                    column: x => x.ToDoListId,
                    principalTable: "ToDoLists",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Tasks_ToDoListId",
            table: "Tasks",
            column: "ToDoListId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Tasks");
    }
}
