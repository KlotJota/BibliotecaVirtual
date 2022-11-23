using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Models.DTOs
{
    internal class LivroAtualizaDto
    {
        public int LivroId { get; set; }
        public string ImagemUrl { get; set; }
        public string NomeLivro { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public int Quantidade { get; set; }
        public int QtdPaginas { get; set; }
        public string Editora { get; set; }
    }
}
