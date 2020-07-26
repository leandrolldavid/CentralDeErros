using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodenationCadastroLogErro.Dados.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoLog",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    level = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    password = table.Column<string>(maxLength: 255, nullable: false),
                    role = table.Column<string>(maxLength: 100, nullable: true),
                    setorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Setor_setorId",
                        column: x => x.setorId,
                        principalTable: "Setor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(maxLength: 500, nullable: false),
                    descricao = table.Column<string>(maxLength: 500, nullable: false),
                    detalhes = table.Column<string>(maxLength: 200, nullable: false),
                    evento = table.Column<int>(nullable: false),
                    tipoLogId = table.Column<int>(nullable: false),
                    origim = table.Column<string>(maxLength: 100, nullable: false),
                    arquivar = table.Column<bool>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Logs_TipoLog_tipoLogId",
                        column: x => x.tipoLogId,
                        principalTable: "TipoLog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Usuario_userId",
                        column: x => x.userId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_tipoLogId",
                table: "Logs",
                column: "tipoLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_userId",
                table: "Logs",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_setorId",
                table: "Usuario",
                column: "setorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "TipoLog");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Setor");
        }
    }
}
