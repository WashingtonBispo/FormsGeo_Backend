using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsGeo.Data.Migrations
{
    public partial class AddFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    idForm = table.Column<string>(type: "text", nullable: false),
                    questions = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    linkConsent = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    finalMessage = table.Column<string>(type: "text", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    gatherEnd = table.Column<bool>(type: "boolean", nullable: false),
                    gatherPassage = table.Column<bool>(type: "boolean", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.idForm);
                });

            migrationBuilder.CreateTable(
                name: "FormEntityUserEntity",
                columns: table => new
                {
                    FormsidForm = table.Column<string>(type: "text", nullable: false),
                    UsersEmail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormEntityUserEntity", x => new { x.FormsidForm, x.UsersEmail });
                    table.ForeignKey(
                        name: "FK_FormEntityUserEntity_Form_FormsidForm",
                        column: x => x.FormsidForm,
                        principalTable: "Form",
                        principalColumn: "idForm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormEntityUserEntity_User_UsersEmail",
                        column: x => x.UsersEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormEntityUserEntity_UsersEmail",
                table: "FormEntityUserEntity",
                column: "UsersEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormEntityUserEntity");

            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
