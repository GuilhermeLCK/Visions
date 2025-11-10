namespace Visions.Application.DTOs.Emprestimo.Respondes
{
    public class EmprestimoAtrasadoDTO
    {
        public string Aluno { get; set; }
        public string Livro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public int DiasAtraso { get; set; }
    }
}
