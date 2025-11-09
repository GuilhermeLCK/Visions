namespace Visions.Application.DTOs.Emprestimo.Respondes
{
    public class EmprestimoListDTO
    {
        public long Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public DateTime? DataDevolucaoReal { get; set; }
        public string Status { get; set; }
        public string NomeAluno { get; set; }
        public string TituloLivro { get; set; }
    }
}
