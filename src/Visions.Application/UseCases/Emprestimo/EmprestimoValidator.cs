using FluentValidation;
using Visions.Application.DTOs.Emprestimo.Requests;
using Visions.Domain.Enum;

public class EmprestimoValidator : AbstractValidator<EmprestimoRegisterDTO>
{
    public EmprestimoValidator()
    {
        RuleFor(e => e.LivroID)
            .NotEmpty().WithMessage("O ID do livro é obrigatório.");

        RuleFor(e => e.AlunoID)
            .NotEmpty().WithMessage("O ID do aluno é obrigatório.");
    }
}
