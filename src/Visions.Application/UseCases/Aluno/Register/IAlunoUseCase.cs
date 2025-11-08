using Visions.Application.DTOs;
using Visions.Application.DTOs.Aluno.Requests;

namespace Visions.Application.UseCases.Aluno.Register
{
    public interface IAlunoUseCase
    {
         Task<GerericResponse> Execute(AlunoRegisterDTO resquest);
    }
}
