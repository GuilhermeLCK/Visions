using System.ComponentModel.DataAnnotations.Schema;
using Visions.Domain.Enum;

namespace Visions.Domain.Models
{

    [Table("Emprestimo")]
    public class Emprestimo : ModelBase
    {
        public DateTime DataEmprestimo { get; set; } = DateTime.UtcNow;
        public DateTime DataPrevistaDevolucao { get; set; } = DateTime.UtcNow.AddDays(14);
        public DateTime? DataDevolucaoReal { get; set; }
        public byte Status { get; set; } = (byte)EmprestimoStatus.RETIRADO;     
        public long AlunoID { get; set; }   
        public long LivroID { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Livro Livro { get; set; }

    }
}
