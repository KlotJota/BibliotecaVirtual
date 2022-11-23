using BibliotecaVirtual.Api.Entities;
using BibliotecaVirtual.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaVirtual.Api.Mappings

{
    public static class MappingDtos
    {
        public static IEnumerable<CategoriaDto> ConverterCategoriasParaDto(
                                                this IEnumerable<Categoria> categorias)
        {
            return (from categoria in categorias
                    select new CategoriaDto
                    {
                        Id = categoria.Id,
                        Nome = categoria.Nome,
                    }).ToList();
        }

        public static IEnumerable<LivroDto> ConverterLivrosParaDto(
                                            this IEnumerable<Livro> livros)

        {
            return (from livro in livros
                    select new LivroDto
                    {
                        Id = livro.Id,
                        ImagemUrl = livro.ImagemUrl,
                        NomeLivro = livro.NomeLivro,
                        Descricao = livro.Descricao,
                        Autor = livro.Autor,
                        Quantidade = livro.Quantidade,
                        QtdPaginas = livro.QtdPaginas,
                        Editora = livro.Editora,
                        CategoriaId = livro.Categorias.Id,
                        CategoriaNome = livro.Categorias.Nome,
                    }).ToList();
        }

        public static LivroDto ConverterLivroParaDto(this Livro livro)

        {
            return new LivroDto
            {
                Id = livro.Id,
                ImagemUrl = livro.ImagemUrl,
                NomeLivro = livro.NomeLivro,
                Descricao = livro.Descricao,
                Autor = livro.Autor,
                Quantidade = livro.Quantidade,
                QtdPaginas = livro.QtdPaginas,
                Editora = livro.Editora,
                CategoriaId = livro.Categorias.Id,
                CategoriaNome = livro.Categorias.Nome
            };
        }

        // Get para locações e livro

        public static IEnumerable<LocacaoLivroDto> ConverterLocacoesLivrosParaDto(
        this IEnumerable<LocacaoLivro> locacoesLivros, IEnumerable<Livro> livros)
        {
            return (from locacaoLivro in locacoesLivros
                    join livro in livros
                    on locacaoLivro.LivroId equals livro.Id
                    select new LocacaoLivroDto
                    {
                        Id = locacaoLivro.Id,
                        LocacaoId = locacaoLivro.LocacaoId,
                        LivroId = locacaoLivro.LivroId,
                        Quantidade = locacaoLivro.Quantidade,

                        ImagemUrl = livro.ImagemUrl,
                        LivroNome = livro.NomeLivro,
                        LivroDescricao = livro.Descricao,
                        LivroAutor = livro.Autor,
                        LivroQtdPaginas = livro.QtdPaginas,
                        LivroEditora = livro.Editora
                    }).ToList();
        }

        public static LocacaoLivroDto ConverterLocacaoLivroParaDto(
                                        this LocacaoLivro locacaoLivro, Livro livro)
        {
            return new LocacaoLivroDto
            {
                Id = locacaoLivro.Id,
                LocacaoId = locacaoLivro.LocacaoId,
                LivroId = locacaoLivro.LivroId,
                Quantidade = locacaoLivro.Quantidade,

                ImagemUrl = livro.ImagemUrl,
                LivroNome = livro.NomeLivro,
                LivroDescricao = livro.Descricao,
                LivroAutor = livro.Autor,
                LivroQtdPaginas = livro.QtdPaginas,
                LivroEditora = livro.Editora
            };
        }

        // Get para favoritos e livro

        public static IEnumerable<FavoritoLivroDto> ConverterFavoritosLivrosParaDto(
        this IEnumerable<FavoritoLivro> favoritosLivros, IEnumerable<Livro> livros)
        {
            return (from favoritoLivro in favoritosLivros
                    join livro in livros
                    on favoritoLivro.LivroId equals livro.Id
                    select new FavoritoLivroDto
                    {
                        Id = favoritoLivro.Id,
                        FavoritoId = favoritoLivro.FavoritoId,
                        LivroId = favoritoLivro.LivroId,

                        ImagemUrl = livro.ImagemUrl,
                        LivroNome = livro.NomeLivro,
                        LivroDescricao = livro.Descricao,
                        LivroAutor = livro.Autor,
                        LivroQtdPaginas = livro.QtdPaginas,
                        LivroEditora = livro.Editora
                    }).ToList();
        }

        public static FavoritoLivroDto ConverterFavoritoLivroParaDto(
                                        this FavoritoLivro favoritoLivro, Livro livro)
        {
            return new FavoritoLivroDto
            {
                Id = favoritoLivro.Id,
                FavoritoId = favoritoLivro.FavoritoId,
                LivroId = favoritoLivro.LivroId,

                ImagemUrl = livro.ImagemUrl,
                LivroNome = livro.NomeLivro,
                LivroDescricao = livro.Descricao,
                LivroAutor = livro.Autor,
                LivroQtdPaginas = livro.QtdPaginas,
                LivroEditora = livro.Editora
            };
        }

        // Mappings para alunos/ cursos

        public static IEnumerable<CursoDto> ConverterCursosParaDto(
                                                this IEnumerable<Curso> cursos)
        {
            return (from curso in cursos
                    select new CursoDto
                    {
                        Id = curso.Id,
                        Nome = curso.Nome,
                        Turno = curso.Turno
                    }).ToList();
        }

        public static IEnumerable<AlunoDto> ConverterAlunosParaDto(
                                            this IEnumerable<Aluno> alunos)

        {
            return (from aluno in alunos
                    select new AlunoDto
                    {
                        Id = aluno.Id,
                        Nome = aluno.Nome,
                        Cpf = aluno.Cpf,
                        Senha = aluno.Senha,
                        Telefone = aluno.Telefone,
                        Email = aluno.Email,
                        Ra = aluno.Ra,
                        CursoId = aluno.Cursos.Id,
                        CursoNome = aluno.Cursos.Nome,
                        CursoTurno = aluno.Cursos.Turno
                    }).ToList();
        }

        public static AlunoDto ConverterAlunoParaDto(this Aluno aluno)

        {
            return new AlunoDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                Senha = aluno.Senha,
                Telefone = aluno.Telefone,
                Email = aluno.Email,
                Ra = aluno.Ra,
                CursoId = aluno.Cursos.Id,
                CursoNome = aluno.Cursos.Nome,
                CursoTurno = aluno.Cursos.Turno
            };
        }
    }
}
