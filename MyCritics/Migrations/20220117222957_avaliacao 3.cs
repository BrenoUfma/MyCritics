using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCritics.Migrations
{
    public partial class avaliacao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotaAtor",
                table: "Avaliacao",
                newName: "NotaFilme");

            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Avaliacao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Avaliacao");

            migrationBuilder.RenameColumn(
                name: "NotaFilme",
                table: "Avaliacao",
                newName: "NotaAtor");
        }
    }
}
