using BibliotecaVirtual.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Api.Context;
public class BDBiblioteca : DbContext
{
    public BDBiblioteca(DbContextOptions<BDBiblioteca> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }
    public DbSet<LocacaoLivro> LocacoesLivros { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Favorito> Favoritos { get; set; }
    public DbSet<FavoritoLivro> FavoritoLivros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 1,
            Nome = "Programação"
        });
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 2,
            Nome = "Administração"
        });
        modelBuilder.Entity<Categoria>().HasData(new Categoria
        {
            Id = 3,
            Nome = "Arquitetura"
        });

        // Dados dos livros
        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 1,
            ImagemUrl = "/Livros/livro1.png",
            NomeLivro = "O Codificador Limpo",
            Descricao = "O Codificador Limpo contém muitos conselhos pragmáticos que visam transformar o comportamento do profissional de software. O autor transmite valiosos ensinamentos sobre ética, respeito, responsabilidade, sinceridade e comprometimento, através de sua experiência como programador.",
            Autor = "Steven Spielberg",
            QtdPaginas = 198,
            Quantidade = 5,
            Editora = "Nova",
            CategoriaId = 1
        });

        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 2,
            ImagemUrl = "/Livros/livro2.png",
            NomeLivro = "Curso Intensivo de Pyhton",
            Descricao = "Curso Intensivo de Python é uma introdução completa e em ritmo acelerado à linguagem Python, que fará você escrever programas, resolver problemas e criar soluções que funcionarão em um piscar de olhos",
            Autor = "Joao",
            QtdPaginas = 120,
            Quantidade = 8,
            Editora = "Velha",
            CategoriaId = 1
        });

        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 3,
            ImagemUrl = "/Livros/livro5.jpg",
            NomeLivro = "Lógica de programação e algoritmos com JavaScript",
            Descricao = "Os conteúdos abordados em Lógica de Programação e Algoritmos são fundamentais a todos aqueles que desejam ingressar no universo da Programação de Computadores. Esses conteúdos, no geral, impõem algumas dificuldades aos iniciantes.",
            Autor = "Alexandre",
            QtdPaginas = 180,
            Quantidade = 4,
            Editora = "Massa",
            CategoriaId = 1
        });

        // Categoria 2 - Adm
        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 4,
            ImagemUrl = "/Livros/livro3.png",
            NomeLivro = "Algoritmos e Lógica de Programação",
            Descricao = "Com linguagem simples e didática – sem, no entanto, fugir da complexidade do assunto –, o livro procura tornar prática a lógica de programação, além de mostrar aos estudantes um caminho mais adequado na construção dos algoritmos. ",
            Autor = "Boisés Camilo",
            QtdPaginas = 100,
            Quantidade = 2,
            Editora = "Boisés Inc.",
            CategoriaId = 2
        });

        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 5,
            ImagemUrl = "/Livros/livro6.png",
            NomeLivro = "JAVA 8 - Programação de computadores",
            Descricao = "Contempla métodos de operações matemáticas, manipulação de cadeias de caracteres e conversão de tipos de dados. Aborda o conceito de métodos e pacotes, e os tipos de arranjos (unidimensional, bidimensional, com argumentos e de classe).",
            Autor = "Carlito Teves",
            QtdPaginas = 110,
            Quantidade = 5,
            Editora = "Tadeu",
            CategoriaId = 2
        });

        // Categoria 3 - Arquitetura

        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 6,
            ImagemUrl = "/Livros/livro4.png",
            NomeLivro = "O Cemitério",
            Descricao = "Pet Sematary é um romance de terror escrito por Stephen King. Foi lançado em 1983.",
            Autor = "Steven Spielberg",
            QtdPaginas = 160,
            Quantidade = 3,
            Editora = "Massa",
            CategoriaId = 3
        });

        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 7,
            ImagemUrl = "/Livros/livro7.jpg",
            NomeLivro = "Programação em C",
            Descricao = "Programação em C é um livro que ensina conceitos e ideias sobre a linguagem C",
            Autor = "Maria Almeida",
            QtdPaginas = 90,
            Quantidade = 2,
            Editora = "Abóbora",
            CategoriaId = 3
        });

        // Adicionar Cursos
        modelBuilder.Entity<Curso>().HasData(new Curso
        {
            Id = 1,
            Nome = "Ads",
            Turno = "Tarde"
        });
        modelBuilder.Entity<Curso>().HasData(new Curso
        {
            Id = 2,
            Nome = "Informática para negócios",
            Turno = "Noite"
        });

        // Adicionar Aluno
        modelBuilder.Entity<Aluno>().HasData(new Aluno
        {
            Id = 1,
            Nome = "Artur",
            Cpf = "33034799",
            Senha = "paodeakho",
            Telefone = "991726623",
            Email = "artur@gmail.com",
            Ra = "40028922",
            CursoId = 1,
            Status = 2

        });
        modelBuilder.Entity<Aluno>().HasData(new Aluno
        {
            Id = 2,
            Nome = "Zomboid",
            Cpf = "91289123",
            Senha = "casseta15",
            Telefone = "991212662",
            Email = "zomboid@gmail.com",
            Ra = "912903001",
            CursoId = 2,
            Status = 2
        });

        // Adicionar Administrador
        modelBuilder.Entity<Administrador>().HasData(new Administrador
        {
            Id = 3,
            Nome = "Henrique",
            Cpf = "23232421",
            Senha = "churrasco12",
            Telefone = "991726623",
            Email = "henrique@gmail.com",
            Status = 1
        });

        // Adicionar Locacao para cada usuários
        modelBuilder.Entity<Locacao>().HasData(new Locacao
        {
            Id = 1,
            AlunoId = "1"
        });
        modelBuilder.Entity<Locacao>().HasData(new Locacao
        {
            Id = 2,
            AlunoId = "2"
        });

        // Adicionar Favorito para cada usuários
        modelBuilder.Entity<Favorito>().HasData(new Favorito
        {
            Id = 1,
            AlunoId = "1"
        });
        modelBuilder.Entity<Favorito>().HasData(new Favorito
        {
            Id = 2,
            AlunoId = "2"
        });
    }
}
