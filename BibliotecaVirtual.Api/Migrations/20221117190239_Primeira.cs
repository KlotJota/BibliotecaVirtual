using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaVirtual.Api.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritos_Livros_LivroId",
                table: "Favoritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_FavoritoLivros_FavoritoLivroId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LocacoesLivros_LocacaoLivroId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Livros_LivroId",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_LivroId",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Livros_FavoritoLivroId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_LocacaoLivroId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Favoritos_LivroId",
                table: "Favoritos");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "LocacoesLivros");

            migrationBuilder.DropColumn(
                name: "DataTermino",
                table: "LocacoesLivros");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "FavoritoLivroId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "LocacaoLivroId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Favoritos");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LocacoesLivros_LivroId",
                table: "LocacoesLivros",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritoLivros_LivroId",
                table: "FavoritoLivros",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritoLivros_Livros_LivroId",
                table: "FavoritoLivros",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocacoesLivros_Livros_LivroId",
                table: "LocacoesLivros",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritoLivros_Livros_LivroId",
                table: "FavoritoLivros");

            migrationBuilder.DropForeignKey(
                name: "FK_LocacoesLivros_Livros_LivroId",
                table: "LocacoesLivros");

            migrationBuilder.DropIndex(
                name: "IX_LocacoesLivros_LivroId",
                table: "LocacoesLivros");

            migrationBuilder.DropIndex(
                name: "IX_FavoritoLivros_LivroId",
                table: "FavoritoLivros");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Livros");

            migrationBuilder.AddColumn<string>(
                name: "DataInicio",
                table: "LocacoesLivros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataTermino",
                table: "LocacoesLivros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Locacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoritoLivroId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocacaoLivroId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Favoritos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_LivroId",
                table: "Locacoes",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_FavoritoLivroId",
                table: "Livros",
                column: "FavoritoLivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_LocacaoLivroId",
                table: "Livros",
                column: "LocacaoLivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_LivroId",
                table: "Favoritos",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Livros_LivroId",
                table: "Favoritos",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_FavoritoLivros_FavoritoLivroId",
                table: "Livros",
                column: "FavoritoLivroId",
                principalTable: "FavoritoLivros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LocacoesLivros_LocacaoLivroId",
                table: "Livros",
                column: "LocacaoLivroId",
                principalTable: "LocacoesLivros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Livros_LivroId",
                table: "Locacoes",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id");
        }
    }
}
