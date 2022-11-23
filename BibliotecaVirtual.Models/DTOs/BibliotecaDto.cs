using System.ComponentModel.DataAnnotations;

namespace BibliotecaVirtual.Models.DTOs
{
    public class BibliotecaDto
    {
        [Key]
        public string Cnpj { get; set; }
        public int Acervo { get; set; }
    }
}
