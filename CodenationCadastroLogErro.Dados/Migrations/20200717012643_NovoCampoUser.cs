using Microsoft.EntityFrameworkCore.Migrations;

namespace CodenationCadastroLogErro.Dados.Migrations
{
    public partial class NovoCampoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "arquivar",
                table: "Usuario",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "arquivar",
                table: "Usuario");
        }
    }
}
