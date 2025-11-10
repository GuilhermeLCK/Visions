using AutoMapper;
using Azure.Core;
using Visions.Application.DTOs.Emprestimo.Requests;
using Visions.Application.DTOs.Emprestimo.Respondes;
using Visions.Domain.Enum;
using Visions.Domain.Interfaces;
using Visions.Domain.Models;

namespace Visions.Application.UseCases.Emprestimo
{
    public class EmprestimoUseCase : IEmprestimoUseCase
    {

        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmprestimoUseCase(IEmprestimoRepository emprestimoRepository, IMapper mapper, IUnitOfWork unitOfWork , ILivroRepository livroRepository, IAlunoRepository alunoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _livroRepository = livroRepository;
            _alunoRepository = alunoRepository;
        }

        public async Task<GerericResponse> Register(EmprestimoRegisterDTO resquest)
        {
            var validate = await ValidateRegister(resquest);

            if (!validate.Success)
                return new GerericResponse(validate.Success, validate.Messages);


            var emprestimo = _mapper.Map<Domain.Models.Emprestimo>(resquest);

            await _emprestimoRepository.AddAsync(emprestimo);

            var livro = await _livroRepository.GetById(resquest.LivroID);

            livro.QuantidadeDisponivel--;

            _livroRepository.UpdateAsync(livro);

            await _unitOfWork.CommitAsync();

            return new GerericResponse(true, new List<string> { "Empréstimo registrado com sucesso" });
        }

        public async Task<GerericResponse> Return(long emprestimoId)
        {
            var emprestimo = await _emprestimoRepository.GetByIdAsync(emprestimoId);

            if(emprestimo == null)
                return new GerericResponse(false, new List<string> { "Empréstimo não encontrado." });

            if (emprestimo.Status == (byte)EmprestimoStatus.DEVOLVIDO)
                return new GerericResponse(false, new List<string> { "Empréstimo ja finalizado." });

            emprestimo.DataDevolucaoReal = DateTime.UtcNow;
            emprestimo.Status = (byte)EmprestimoStatus.DEVOLVIDO;

            _emprestimoRepository.AddUpdateAsync(emprestimo);

            var livro = await _livroRepository.GetById(emprestimo.LivroID);

            livro.QuantidadeDisponivel++;

            _livroRepository.UpdateAsync(livro);

            await _unitOfWork.CommitAsync();

            return new GerericResponse(true, new List<string> { "Empréstimo finalizado com sucesso" });

        }

        public async Task<GerericResponse<List<EmprestimoListDTO>>> GetActivesByAluno(long alunoId)
        {
            var emprestimos =  await _emprestimoRepository.GetAssetsByAlunoIdAsync(alunoId);

            if(emprestimos == null)
                return new GerericResponse<List<EmprestimoListDTO>>(null, false, new List<string> { "Empréstimo não encontrado para esse aluno." });

            var emprestimosDTO = _mapper.Map<List<EmprestimoListDTO>>(emprestimos);

            return new GerericResponse<List<EmprestimoListDTO>>(emprestimosDTO, true);

        }


        public async Task<GerericResponse<List<EmprestimoTopDTO>>> GetTop()
        {
            var result = await _emprestimoRepository.GetTopAsync<EmprestimoTopDTO>();
            return new GerericResponse<List<EmprestimoTopDTO>>(result, true);
        }

        public async Task<GerericResponse<List<EmprestimoAtrasadoDTO>>> GetDelayedLoans()
        {
            var emprestimos = await _emprestimoRepository.GetDelayedLoansAsync<EmprestimoAtrasadoDTO>();
            return new GerericResponse<List<EmprestimoAtrasadoDTO>>(emprestimos, true);
        }

        public async Task<GerericResponse<List<EmprestimoHistoricoDTO>>> GetHistoryByPeriod(DateTime? inicio, DateTime? fim)
        {
            var emprestimos = await _emprestimoRepository.GetHistoryByPeriodAsync<EmprestimoHistoricoDTO>(inicio, fim);
            return new GerericResponse<List<EmprestimoHistoricoDTO>>(emprestimos, true);
        }


        private async Task<GerericResponse> ValidateRegister(EmprestimoRegisterDTO resquest)
        {
            var validator = new EmprestimoValidator();

            var validatorResult = validator.Validate(resquest);

            if (!validatorResult.IsValid)
            {
                return new GerericResponse(validatorResult.IsValid, validatorResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            var livro = await _livroRepository.GetById(resquest.LivroID);

            if(livro == null)
                return new GerericResponse(false, new List<string> { "Livro não encontrado." });


            if(livro.QuantidadeDisponivel == 0)
                return new GerericResponse(false, new List<string> { "Esse livro não tem exemplares disponíveis." });


            var aluno = await _alunoRepository.GetById(resquest.AlunoID);

            if (aluno == null)
                return new GerericResponse(false, new List<string> { "Aluno não encontrado." });
            if (!aluno.Ativo)
                return new GerericResponse(false, new List<string> { "Aluno com cadastro inativo." });

            var emprestimoPorAluno = await _emprestimoRepository.GetAssetsByAlunoIdAsync(resquest.AlunoID);

            if (emprestimoPorAluno.Count >= 3)
                return new GerericResponse(false, new List<string> { "Aluno já possui 3 empréstimos ativos." });

            var emprestimosPendentes = await _emprestimoRepository.GetDelayedLoansAsync<EmprestimoAtrasadoDTO>(resquest.AlunoID);

            if (emprestimosPendentes.Any())
                return new GerericResponse(false, new List<string> { "Aluno possui empréstimos em atraso." });  


            return new GerericResponse(true);
        }

    }
}
