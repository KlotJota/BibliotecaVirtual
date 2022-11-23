namespace BibliotecaVirtual.Models.DTOs
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public string Ra { get; set; }

        public int CursoId { get; set; }
        public string CursoNome { get; set; }
        public string CursoTurno { get; set; }
    }
}
