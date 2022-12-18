using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormsGeo.Data.Migrations
{
    public partial class AddAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    answerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    answer = table.Column<string>(type: "text", nullable: false),
                    geolocation = table.Column<string>(type: "text", nullable: false),
                    typeAnswer = table.Column<int>(type: "integer", nullable: false),
                    idParticipante = table.Column<string>(type: "text", nullable: false),
                    FormidForm = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.answerId);
                    table.ForeignKey(
                        name: "FK_Answer_Form_FormidForm",
                        column: x => x.FormidForm,
                        principalTable: "Form",
                        principalColumn: "idForm",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_FormidForm",
                table: "Answer",
                column: "FormidForm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");
        }
    }
}
