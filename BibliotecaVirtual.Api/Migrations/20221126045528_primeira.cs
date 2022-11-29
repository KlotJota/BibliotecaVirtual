using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaVirtual.Api.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeLivro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    QtdPaginas = table.Column<int>(type: "int", nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livros_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LocacoesId = table.Column<int>(type: "int", nullable: true),
                    FavoritosId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Favoritos_FavoritosId",
                        column: x => x.FavoritosId,
                        principalTable: "Favoritos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Locacoes_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "Locacoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoritoLivros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    FavoritoId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritoLivros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritoLivros_Favoritos_FavoritoId",
                        column: x => x.FavoritoId,
                        principalTable: "Favoritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritoLivros_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocacoesLivros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    LocacaoId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacoesLivros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocacoesLivros_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacoesLivros_Locacoes_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Programação" },
                    { 2, "Administração" },
                    { 3, "Arquitetura" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome", "Turno" },
                values: new object[,]
                {
                    { 1, "Ads", "Tarde" },
                    { 2, "Informática para negócios", "Noite" }
                });

            migrationBuilder.InsertData(
                table: "Favoritos",
                columns: new[] { "Id", "AlunoId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" }
                });

            migrationBuilder.InsertData(
                table: "Locacoes",
                columns: new[] { "Id", "AlunoId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf", "Discriminator", "Email", "FavoritosId", "LocacoesId", "Nome", "Senha", "Status", "Telefone" },
                values: new object[] { 3, "23232421", "Administrador", "henrique@gmail.com", null, null, "Henrique", "churrasco12", 1, "991726623" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "CategoriaId", "Descricao", "Editora", "ImagemUrl", "NomeLivro", "QtdPaginas", "Quantidade" },
                values: new object[,]
                {
                    { 1, "Steven Spielberg", 1, "O Codificador Limpo contém muitos conselhos pragmáticos que visam transformar o comportamento do profissional de software. O autor transmite valiosos ensinamentos sobre ética, respeito, responsabilidade, sinceridade e comprometimento, através de sua experiência como programador.", "Nova", "/Livros/livro1.png", "O Codificador Limpo", 198, 5 },
                    { 2, "Joao", 1, "Curso Intensivo de Python é uma introdução completa e em ritmo acelerado à linguagem Python, que fará você escrever programas, resolver problemas e criar soluções que funcionarão em um piscar de olhos", "Velha", "/Livros/livro2.png", "Curso Intensivo de Pyhton", 120, 8 },
                    { 3, "Alexandre", 1, "Os conteúdos abordados em Lógica de Programação e Algoritmos são fundamentais a todos aqueles que desejam ingressar no universo da Programação de Computadores. Esses conteúdos, no geral, impõem algumas dificuldades aos iniciantes.", "Massa", "/Livros/livro5.jpg", "Lógica de programação e algoritmos com JavaScript", 180, 4 },
                    { 4, "Boisés Camilo", 2, "Com linguagem simples e didática – sem, no entanto, fugir da complexidade do assunto –, o livro procura tornar prática a lógica de programação, além de mostrar aos estudantes um caminho mais adequado na construção dos algoritmos. ", "Boisés Inc.", "/Livros/livro3.png", "Algoritmos e Lógica de Programação", 100, 2 },
                    { 5, "Carlito Teves", 2, "Contempla métodos de operações matemáticas, manipulação de cadeias de caracteres e conversão de tipos de dados. Aborda o conceito de métodos e pacotes, e os tipos de arranjos (unidimensional, bidimensional, com argumentos e de classe).", "Tadeu", "/Livros/livro6.png", "JAVA 8 - Programação de computadores", 110, 5 },
                    { 6, "Steven Spielberg", 3, "Pet Sematary é um romance de terror escrito por Stephen King. Foi lançado em 1983.", "Massa", "/Livros/livro4.png", "O Cemitério", 160, 3 },
                    { 7, "Maria Almeida", 3, "Programação em C é um livro que ensina conceitos e ideias sobre a linguagem C", "Abóbora", "/Livros/livro7.jpg", "Programação em C", 90, 2 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf", "CursoId", "Discriminator", "Email", "FavoritosId", "LocacoesId", "Nome", "Ra", "Senha", "Status", "Telefone" },
                values: new object[,]
                {
                    { 1, "33034799", 1, "Aluno", "artur@gmail.com", null, null, "Artur", "40028922", "paodeakho", 2, "991726623" },
                    { 2, "91289123", 2, "Aluno", "zomboid@gmail.com", null, null, "Zomboid", "912903001", "casseta15", 2, "991212662" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritoLivros_FavoritoId",
                table: "FavoritoLivros",
                column: "FavoritoId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritoLivros_LivroId",
                table: "FavoritoLivros",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_CategoriaId",
                table: "Livros",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacoesLivros_LivroId",
                table: "LocacoesLivros",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacoesLivros_LocacaoId",
                table: "LocacoesLivros",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CursoId",
                table: "Usuarios",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FavoritosId",
                table: "Usuarios",
                column: "FavoritosId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_LocacoesId",
                table: "Usuarios",
                column: "LocacoesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritoLivros");

            migrationBuilder.DropTable(
                name: "LocacoesLivros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
