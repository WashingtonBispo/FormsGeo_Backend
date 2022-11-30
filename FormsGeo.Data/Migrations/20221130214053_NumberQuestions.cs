using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsGeo.Data.Migrations
{
    public partial class NumberQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numberQuestions",
                table: "Form",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numberQuestions",
                table: "Form");
        }
    }
}
