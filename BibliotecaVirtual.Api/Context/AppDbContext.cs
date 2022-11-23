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
    public DbSet<Biblioteca> Bibliotecas { get; set; }
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
            Descricao = "Este livro é muito bom",
            Autor = "Steven Spielberg",
            QtdPaginas = 198,
            Editora = "Nova",
            CategoriaId = 1
        });

        // Categoria 2 - Adm
        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 2,
            ImagemUrl = "/Livros/livro2.png",
            NomeLivro = "Curso Intensivo de Pyhton",
            Descricao = "Este livro é muito bala foda pra porra",
            Autor = "Ducatti",
            QtdPaginas = 120,
            Editora = "Velha",
            CategoriaId = 2
        });

        // Categoria 3 - Arquitetura
        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 3,
            ImagemUrl = "/Livros/livro3.png",
            NomeLivro = "Algoritmos e Lógica de Programação",
            Descricao = "Este livro é muito grande Boisé quem o diga",
            Autor = "Boisés Camilo",
            QtdPaginas = 100,
            Editora = "Boisés Inc.",
            CategoriaId = 3
        });
        modelBuilder.Entity<Livro>().HasData(new Livro
        {
            Id = 4,
            ImagemUrl = "/Livros/livro4.png",
            NomeLivro = "O Cemitério",
            Descricao = "Que que essa porra de livro ta fazendo aqui",
            Autor = "Steven Spielberg",
            QtdPaginas = 160,
            Editora = "Casseta",
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
            CursoId = 1
            
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
            CursoId = 2

        });

        // Adicionar Administrador
        modelBuilder.Entity<Administrador>().HasData(new Administrador
        {
            Id = 3,
            Nome = "Henrique",
            Cpf = "23232421",
            Senha = "churrasco12",
            Telefone = "991726623",
            Email = "henrique@gmail.com"
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
            AlunoId = '1'
        });
        modelBuilder.Entity<Favorito>().HasData(new Favorito
        {
            Id = 2,
            AlunoId = '2'
        });
    }
}
