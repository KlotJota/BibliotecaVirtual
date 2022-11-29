using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BibliotecaVirtual.Models.DTOs
{
    public class AdicionaLivroDto
    {
        public string? ImagemUrl { get; set; }
        [Required]
        public string NomeLivro { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Autor { get; set; }
        public int Quantidade { get; set; }
        [Required]
        public int QtdPaginas { get; set; }
        public string Editora { get; set; }

        public int CategoriaId { get; set; }
       
    }
}
