using System.ComponentModel.DataAnnotations;

namespace BibliotecaVirtual.Api.Entities

{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public Locacao? Locacoes { get; set; }
        public Favorito? Favoritos { get; set; }
    }
}
