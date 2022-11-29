using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Models.DTOs
{
    public class FavoritoAdicionaLivroDto
    {
        [Required]
        public int FavoritoId { get; set; }
        [Required]
        public int LivroId { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
