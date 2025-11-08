using FluentValidation;
using Visions.Application.DTOs.Livro.Requests;

namespace Visions.Application.UseCase.Livro.Register
{
    public class LivroValidator : AbstractValidator<LivroRegisterDTO>
    {
        public LivroValidator()
        {
            RuleFor(l => l.Titulo)
                .NotEmpty().WithMessage("O título do livro é obrigatório.")
                .MinimumLength(4)
                .MaximumLength(200).WithMessage("O título do livro não pode exceder 200 caracteres.");

            RuleFor(l => l.Autor)
              .MinimumLength(4)
              .NotEmpty().WithMessage("O nome do Autor do livro é obrigatório.");

            RuleFor(l => l.ISBN)
            .MinimumLength(13)
            .NotEmpty().WithMessage("ISBN é obrigatório.")
            .MaximumLength(13).WithMessage("Um ISBN tem 13 dígitos.");

            RuleFor(l => l.Categoria)
           .MinimumLength(4)
           .NotEmpty().WithMessage("Categoria do livro é obrigatório.");

            RuleFor(x => x.AnoPublicacao)
             .InclusiveBetween(1000, 9999)
             .WithMessage("O ano de publicação deve conter 4 dígitos válidos.");

            RuleFor(l => l.QuantidadeTotal)
                .GreaterThan(0).WithMessage("A quantidade total deve ser maior que zero.");

            RuleFor(l => l.QuantidadeDisponivel)
             .GreaterThan(0).WithMessage("A quantidade disponível deve ser maior que zero.");

        }
    }
}