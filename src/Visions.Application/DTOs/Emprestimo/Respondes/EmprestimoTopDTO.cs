namespace Visions.Application.DTOs.Emprestimo.Respondes
{
    public class EmprestimoTopDTO
    {
        public string Livro { get; set; }
        public int TotalEmprestimos { get; set; }
        public string PrimeiroAluno { get; set; }
        public string UltimoAluno { get; set; }
        public string AlunoMaisFrequente { get; set; }
    }
}
