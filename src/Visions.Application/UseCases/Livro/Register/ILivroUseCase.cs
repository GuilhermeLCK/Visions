using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.DTOs;

namespace Visions.Application.UseCases.Livro.Register
{
    public interface ILivroUseCase
    {
         Task<GerericResponse> Execute(LivroRegisterDTO resquest);
    }
}
