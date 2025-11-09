using Visions.Application.DTOs;
using Visions.Application.DTOs.Aluno.Requests;
using Visions.Domain.Models;

namespace Visions.Application.UseCases.Aluno
{
    public interface IAlunoUseCase
    {
        Task<GerericResponse> Register(AlunoRegisterDTO resquest);
    }
}
