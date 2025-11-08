using AutoMapper;
using Visions.Application.DTOs;
using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.DTOs.Livro.Responses;
using Visions.Domain.Interfaces;

namespace Visions.Application.UseCases.Livro.Listing
{
    public class LivroListingUseCase : ILivroListingUseCase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;


        public LivroListingUseCase(ILivroRepository livroRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }
        public async Task<GerericResponse<List<LivroListDTO>>> ExecuteAll(LivroFiltersDTO filters)
        {

            List<Domain.Models.Livro> livros = await _livroRepository.GetByFilterAsync(filters.Titulo, filters.Autor, filters.Isbn);
            var livrosFiltrados = _mapper.Map<List<LivroListDTO>>(livros);
            var response = new GerericResponse<List<LivroListDTO>>(livrosFiltrados, true);
            return response;

        }

        public async Task<GerericResponse<List<LivroListDTO>>> ExecuteAvailable()
        {
            List<Domain.Models.Livro> livrosDisponiveis = await _livroRepository.GetAvailablesAsync();
            var livrosFiltrados = _mapper.Map<List<LivroListDTO>>(livrosDisponiveis);
            var response = new GerericResponse<List<LivroListDTO>>(livrosFiltrados, true);
            return response;

        }
    }
}
