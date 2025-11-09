using System.ComponentModel.DataAnnotations.Schema;

namespace Visions.Domain.Models
{

    [Table("Aluno")]
    public class Aluno : ModelBase
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty; 
        public string Curso { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;  

    }
}
