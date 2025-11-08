using FluentValidation;
using Visions.Application.DTOs.Aluno.Requests;

namespace Visions.Application.UseCases.Aluno.Register
{
    class AlunoValidator : AbstractValidator<AlunoRegisterDTO>
    {
        public AlunoValidator()
        {
            RuleFor(l => l.Nome)
              .NotEmpty().WithMessage("O nome do aluno é obrigatório.")
              .MinimumLength(3);

            RuleFor(l => l.Curso)
             .NotEmpty().WithMessage("O curso do aluno é obrigatório.")
             .MinimumLength(3);

            RuleFor(l => l.Email)
               .NotEmpty().WithMessage("O e-mail do aluno é obrigatório.")
               .EmailAddress();

        }
    }
}
