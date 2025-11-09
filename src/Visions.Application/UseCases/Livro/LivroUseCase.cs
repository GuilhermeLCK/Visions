using AutoMapper;
using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.DTOs.Livro.Responses;
using Visions.Domain.Interfaces;
using Visions.Domain.Models;

namespace Visions.Application.UseCases.Livro
{
    public class LivroUseCase : ILivroUseCase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LivroUseCase(ILivroRepository livroRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GerericResponse> Register(LivroRegisterDTO resquest)
        {
            var validate = Validate(resquest);

            if (!validate.Success)
                return new GerericResponse(validate.Success, validate.Messages);

            var livroJaExiste = await _livroRepository.GetExistByIsbnAsync(resquest.ISBN);

            if (livroJaExiste != null)
            {
                return new GerericResponse(false, new List<string> { "Já existe um livro cadastrado com esse ISBN" });
            }

            var livro = _mapper.Map<Domain.Models.Livro>(resquest);

            await _livroRepository.AddAsync(livro);

            await _unitOfWork.CommitAsync();

            return new GerericResponse(true, new List<string> { "Livro cadastrado com sucesso" });

        }
        public async Task<GerericResponse<List<LivroListDTO>>> GetAll(LivroFiltersDTO filters)
        {

            List<Domain.Models.Livro> livros = await _livroRepository.GetByFilterAsync(filters.Titulo, filters.Autor, filters.Isbn);
            var livrosFiltrados = _mapper.Map<List<LivroListDTO>>(livros);
            var response = new GerericResponse<List<LivroListDTO>>(livrosFiltrados, true);
            return response;

        }
        public async Task<GerericResponse<List<LivroListDTO>>> GetAvailable()
        {
            List<Domain.Models.Livro> livrosDisponiveis = await _livroRepository.GetAvailablesAsync();
            var livrosFiltrados = _mapper.Map<List<LivroListDTO>>(livrosDisponiveis);
            var response = new GerericResponse<List<LivroListDTO>>(livrosFiltrados, true);
            return response;

        }

        private GerericResponse Validate(LivroRegisterDTO resquest)
        {
            var validator = new LivroValidator();

            var validatorResult = validator.Validate(resquest);

            if (!validatorResult.IsValid)
            {
                return new GerericResponse(validatorResult.IsValid, validatorResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            return new GerericResponse(true);
        }

   
    }
}
