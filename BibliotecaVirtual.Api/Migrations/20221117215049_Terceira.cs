using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaVirtual.Api.Migrations
{
    public partial class Terceira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "LocacoesLivros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AlunoId",
                table: "Locacoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Locacoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AlunoId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Locacoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AlunoId",
                value: "2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "LocacoesLivros");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "Locacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Locacoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AlunoId",
                value: 49);

            migrationBuilder.UpdateData(
                table: "Locacoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AlunoId",
                value: 50);
        }
    }
}
