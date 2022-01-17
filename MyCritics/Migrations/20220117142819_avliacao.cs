using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCritics.Migrations
{
    public partial class avliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Usuario_UsuarioID",
                table: "Avaliacao");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Avaliacao",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Usuario_UsuarioID",
                table: "Avaliacao",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Usuario_UsuarioID",
                table: "Avaliacao");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Avaliacao",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Usuario_UsuarioID",
                table: "Avaliacao",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
