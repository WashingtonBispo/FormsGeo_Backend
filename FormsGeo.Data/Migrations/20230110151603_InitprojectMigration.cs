using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsGeo.Data.Migrations
{
    public partial class InitprojectMigration : Migration
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
                    numberQuestions = table.Column<int>(type: "integer", nullable: true),
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
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    isAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    idParticipante = table.Column<string>(type: "text", nullable: false),
                    FormId = table.Column<string>(type: "text", nullable: false),
                    answerId = table.Column<int>(type: "integer", nullable: false),
                    answer = table.Column<string>(type: "text", nullable: false),
                    geolocation = table.Column<string>(type: "text", nullable: false),
                    typeAnswer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => new { x.FormId, x.idParticipante });
                    table.ForeignKey(
                        name: "FK_Answer_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "idForm",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    idLocal = table.Column<string>(type: "text", nullable: false),
                    radius = table.Column<int>(type: "integer", nullable: false),
                    longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    formidForm = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Local_formidForm",
                table: "Local",
                column: "formidForm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "FormEntityUserEntity");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
