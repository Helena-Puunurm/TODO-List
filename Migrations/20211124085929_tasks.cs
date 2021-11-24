using Microsoft.EntityFrameworkCore.Migrations;

namespace TARpe19TodoApp.Migrations
{
    public partial class tasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Expected_Deadline = table.Column<string>(type: "TEXT", nullable: true),
                    Task_Size = table.Column<string>(type: "TEXT", nullable: true),
                    Study_Materials = table.Column<string>(type: "TEXT", nullable: true),
                    Task_Type = table.Column<string>(type: "TEXT", nullable: true),
                    Information = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");
        }
    }
}
