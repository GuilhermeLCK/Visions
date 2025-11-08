using AutoMapper;
using Visions.Application.DTOs;
using Visions.Application.DTOs.Aluno.Requests;
using Visions.Domain.Interfaces;

namespace Visions.Application.UseCases.Aluno.Register
{
    class AlunoUseCase : IAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoUseCase(IAlunoRepository alunoRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GerericResponse> Execute(AlunoRegisterDTO resquest)
        {
            var validate = Validate(resquest);

            if (!validate.Success)
                return new GerericResponse(validate.Success, validate.Messages);


            var aluno = _mapper.Map<Domain.Models.Aluno>(resquest);

            aluno.Matricula = GerarMatricula();

            await _alunoRepository.AddAsync(aluno);

            await _unitOfWork.CommitAsync();

            return new GerericResponse(true, new List<string> { "Aluno cadastrado com sucesso" });

        }

        private  string GerarMatricula()
        {
            return $"MAT-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";

        }

        private GerericResponse Validate(AlunoRegisterDTO resquest)
        {
            var validator = new AlunoValidator();

            var validatorResult = validator.Validate(resquest);

            if (!validatorResult.IsValid)
            {
                return new GerericResponse(validatorResult.IsValid, validatorResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            return new GerericResponse(true);
        }
    }
}
