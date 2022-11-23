using System.ComponentModel.DataAnnotations;

namespace BibliotecaVirtual.Api.Entities
{
    public class Biblioteca
    {
        [Key]
        public string Cnpj { get; set; }
        public int Acervo { get; set; }
    }
}
