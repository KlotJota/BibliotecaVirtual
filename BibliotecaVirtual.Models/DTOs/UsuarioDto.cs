using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual.Models.DTOs
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public int Status { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
