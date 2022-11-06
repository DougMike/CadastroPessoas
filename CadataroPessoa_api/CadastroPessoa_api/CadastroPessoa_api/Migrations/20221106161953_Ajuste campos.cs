using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroPessoa_api.Migrations
{
    public partial class Ajustecampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Pessoas",
                newName: "Uf");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Pessoas",
                newName: "Localidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "Pessoas",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Localidade",
                table: "Pessoas",
                newName: "Cidade");
        }
    }
}
