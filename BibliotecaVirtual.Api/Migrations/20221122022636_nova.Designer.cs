﻿// <auto-generated />
using System;
using BibliotecaVirtual.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaVirtual.Api.Migrations
{
    [DbContext(typeof(BDBiblioteca))]
    [Migration("20221122022636_nova")]
    partial class nova
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Biblioteca", b =>
                {
                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Acervo")
                        .HasColumnType("int");

                    b.HasKey("Cnpj");

                    b.ToTable("Bibliotecas");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Programação"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Administração"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Arquitetura"
                        });
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Ads",
                            Turno = "Tarde"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Informática para negócios",
                            Turno = "Noite"
                        });
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Favorito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Favoritos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlunoId = 49
                        },
                        new
                        {
                            Id = 2,
                            AlunoId = 50
                        });
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.FavoritoLivro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FavoritoId")
                        .HasColumnType("int");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FavoritoId");

                    b.HasIndex("LivroId");

                    b.ToTable("FavoritoLivros");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeLivro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdPaginas")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Livros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Autor = "Steven Spielberg",
                            CategoriaId = 1,
                            Descricao = "Este livro é muito bom",
                            Editora = "Nova",
                            ImagemUrl = "/Livros/livro1.png",
                            NomeLivro = "O Codificador Limpo",
                            QtdPaginas = 198,
                            Quantidade = 0
                        },
                        new
                        {
                            Id = 2,
                            Autor = "Ducatti",
                            CategoriaId = 2,
                            Descricao = "Este livro é muito bala foda pra porra",
                            Editora = "Velha",
                            ImagemUrl = "/Livros/livro2.png",
                            NomeLivro = "Curso Intensivo de Pyhton",
                            QtdPaginas = 120,
                            Quantidade = 0
                        },
                        new
                        {
                            Id = 3,
                            Autor = "Boisés Camilo",
                            CategoriaId = 3,
                            Descricao = "Este livro é muito grande Boisé quem o diga",
                            Editora = "Boisés Inc.",
                            ImagemUrl = "/Livros/livro3.png",
                            NomeLivro = "Algoritmos e Lógica de Programação",
                            QtdPaginas = 100,
                            Quantidade = 0
                        },
                        new
                        {
                            Id = 4,
                            Autor = "Steven Spielberg",
                            CategoriaId = 3,
                            Descricao = "Que que essa porra de livro ta fazendo aqui",
                            Editora = "Casseta",
                            ImagemUrl = "/Livros/livro4.png",
                            NomeLivro = "O Cemitério",
                            QtdPaginas = 160,
                            Quantidade = 0
                        });
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlunoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locacoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlunoId = "1"
                        },
                        new
                        {
                            Id = 2,
                            AlunoId = "2"
                        });
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.LocacaoLivro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("LocacaoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.HasIndex("LocacaoId");

                    b.ToTable("LocacoesLivros");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FavoritosId")
                        .HasColumnType("int");

                    b.Property<int?>("LocacoesId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FavoritosId");

                    b.HasIndex("LocacoesId");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Administrador", b =>
                {
                    b.HasBaseType("BibliotecaVirtual.Api.Entities.Usuario");

                    b.HasDiscriminator().HasValue("Administrador");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Cpf = "23232421",
                            Email = "henrique@gmail.com",
                            Nome = "Henrique",
                            Senha = "churrasco12",
                            Telefone = "991726623"
                        });
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Aluno", b =>
                {
                    b.HasBaseType("BibliotecaVirtual.Api.Entities.Usuario");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Ra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CursoId");

                    b.HasDiscriminator().HasValue("Aluno");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "33034799",
                            Email = "artur@gmail.com",
                            Nome = "Artur",
                            Senha = "paodeakho",
                            Telefone = "991726623",
                            CursoId = 1,
                            Ra = "40028922"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "91289123",
                            Email = "zomboid@gmail.com",
                            Nome = "Zomboid",
                            Senha = "casseta15",
                            Telefone = "991212662",
                            CursoId = 2,
                            Ra = "912903001"
                        });
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.FavoritoLivro", b =>
                {
                    b.HasOne("BibliotecaVirtual.Api.Entities.Favorito", "Favoritos")
                        .WithMany("FavoritoLivros")
                        .HasForeignKey("FavoritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaVirtual.Api.Entities.Livro", "Livros")
                        .WithMany("FavoritosLivros")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Favoritos");

                    b.Navigation("Livros");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Livro", b =>
                {
                    b.HasOne("BibliotecaVirtual.Api.Entities.Categoria", "Categorias")
                        .WithMany("Livros")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.LocacaoLivro", b =>
                {
                    b.HasOne("BibliotecaVirtual.Api.Entities.Livro", "Livros")
                        .WithMany("LocacoesLivros")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaVirtual.Api.Entities.Locacao", "Locacoes")
                        .WithMany("LocacoesLivros")
                        .HasForeignKey("LocacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livros");

                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Usuario", b =>
                {
                    b.HasOne("BibliotecaVirtual.Api.Entities.Favorito", "Favoritos")
                        .WithMany()
                        .HasForeignKey("FavoritosId");

                    b.HasOne("BibliotecaVirtual.Api.Entities.Locacao", "Locacoes")
                        .WithMany()
                        .HasForeignKey("LocacoesId");

                    b.Navigation("Favoritos");

                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Aluno", b =>
                {
                    b.HasOne("BibliotecaVirtual.Api.Entities.Curso", "Cursos")
                        .WithMany("Alunos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Categoria", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Curso", b =>
                {
                    b.Navigation("Alunos");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Favorito", b =>
                {
                    b.Navigation("FavoritoLivros");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Livro", b =>
                {
                    b.Navigation("FavoritosLivros");

                    b.Navigation("LocacoesLivros");
                });

            modelBuilder.Entity("BibliotecaVirtual.Api.Entities.Locacao", b =>
                {
                    b.Navigation("LocacoesLivros");
                });
#pragma warning restore 612, 618
        }
    }
}
