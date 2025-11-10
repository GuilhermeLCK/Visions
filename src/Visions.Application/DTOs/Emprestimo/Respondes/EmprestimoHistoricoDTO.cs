namespace Visions.Application.DTOs.Emprestimo.Respondes
{
    public class EmprestimoHistoricoDTO
    {
        public string Aluno { get; set; }
        public string Livro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public byte Status { get; set; }
    }
}
