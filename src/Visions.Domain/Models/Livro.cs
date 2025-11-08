using System.ComponentModel.DataAnnotations.Schema;

namespace Visions.Domain.Models
{
    [Table("Livro")]
    public class Livro : ModelBase
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public int QuantidadeTotal { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}
