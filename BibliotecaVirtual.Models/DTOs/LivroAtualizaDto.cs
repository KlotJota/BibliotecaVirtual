using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Models.DTOs
{
    public class LivroAtualizaDto
    {
        public int Id { get; set; }
        public string ImagemUrl { get; set; }
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

        public int? CategoriaId { get; set; }
        public string? CategoriaNome { get; set; }
    }
}
