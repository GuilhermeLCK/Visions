namespace Visions.Application.DTOs.Livro.Requests
{
    public class LivroRegisterDTO
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
