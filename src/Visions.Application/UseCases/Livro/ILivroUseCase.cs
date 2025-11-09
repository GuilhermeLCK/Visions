using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.DTOs.Livro.Responses;
using Visions.Domain.Models;

namespace Visions.Application.UseCases.Livro
{
    public interface ILivroUseCase
    {
        Task<GerericResponse> Register(LivroRegisterDTO resquest);
        Task<GerericResponse<List<LivroListDTO>>> GetAll(LivroFiltersDTO filters);
        Task<GerericResponse<List<LivroListDTO>>> GetAvailable();


    }
}
