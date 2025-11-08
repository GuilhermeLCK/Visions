

using AutoMapper;
using Visions.Application.DTOs;
using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.UseCase.Livro.Register;
using Visions.Application.UseCases.Livro.Register;
using Visions.Domain.Interfaces;

namespace Visions.Application.UseCase.Livro.Cadastrar
{
    public class LivroUseCase  : ILivroUseCase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LivroUseCase(ILivroRepository livroRepository , IMapper mapper , IUnitOfWork unitOfWork)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GerericResponse> Execute(LivroRegisterDTO resquest)
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

            return new GerericResponse(true, new List<string> {"Livro cadastrado com sucesso"});

        }

        private GerericResponse Validate(LivroRegisterDTO resquest)
        {
            var validator = new LivroValidator();

            var validatorResult = validator.Validate(resquest);   

            if(!validatorResult.IsValid)
            {
                return new GerericResponse(validatorResult.IsValid,validatorResult.Errors.Select(e => e.ErrorMessage).ToList() );
            }
            return new GerericResponse(true);
        }   
    }
}
