using Visions.Application.DTOs;
using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.DTOs.Livro.Responses;

namespace Visions.Application.UseCases.Livro.Listing
{
    public interface ILivroListingUseCase
    {
        Task<GerericResponse<List<LivroListDTO>>> ExecuteAll(LivroFiltersDTO filters);
        Task<GerericResponse<List<LivroListDTO>>> ExecuteAvailable();
    }
}
