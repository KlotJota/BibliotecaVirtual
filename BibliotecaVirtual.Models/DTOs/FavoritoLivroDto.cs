﻿namespace BibliotecaVirtual.Models.DTOs
{
    public class FavoritoLivroDto
    {
        public int Id { get; set; }
        public int FavoritoId { get; set; }
        public int LivroId { get; set; }

        public string ImagemUrl { get; set; }
        public string LivroNome { get; set; }
        public string LivroDescricao { get; set; }
        public string LivroAutor { get; set; }
        public int LivroQtdPaginas { get; set; }
        public string LivroEditora { get; set; }
    }
}
