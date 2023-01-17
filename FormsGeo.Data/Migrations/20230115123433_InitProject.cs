using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsGeo.Data.Migrations
{
    public partial class InitProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.AddColumn<string>(
                name: "geolocations",
                table: "Form",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "geolocations",
                table: "Form");

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    idLocal = table.Column<string>(type: "text", nullable: false),
                    formidForm = table.Column<string>(type: "text", nullable: false),
                    latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    radius = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.idLocal);
                    table.ForeignKey(
                        name: "FK_Local_Form_formidForm",
                        column: x => x.formidForm,
                        principalTable: "Form",
                        principalColumn: "idForm",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Local_formidForm",
                table: "Local",
                column: "formidForm");
        }
    }
}
