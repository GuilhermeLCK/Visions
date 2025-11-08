using System.ComponentModel.DataAnnotations.Schema;

namespace Visions.Domain.Models
{

    [Table("Emprestimo")]
    public class Emprestimo : ModelBase
    {
        public DateTime DataEmprestimo { get; set; } 
        public DateTime DataPrevistaDevolucao { get; set; }
        public DateTime DataDevolucaoReal { get; set; }
        public byte Status { get; set; }

        public long AlunoID { get; set; }   
        public long LivroID { get; set; }

        public virtual  Aluno Aluno { get; set; }
        public virtual Livro Livro { get; set; }

    }
}
