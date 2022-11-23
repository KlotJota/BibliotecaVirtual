using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BibliotecaVirtual.Models.DTOs
{
    public class LocacaoAdicionaLivroDto
    {
        [Required]
        public int LocacaoId { get; set; }
        [Required]
        public int LivroId { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
