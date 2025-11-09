using Visions.Application.DTOs.Emprestimo.Requests;
using Visions.Application.DTOs.Emprestimo.Respondes;
using Visions.Domain.Models;

namespace Visions.Application.UseCases.Emprestimo
{
    public interface IEmprestimoUseCase
    {
        Task<GerericResponse> Register(EmprestimoRegisterDTO resquest);
        Task<GerericResponse> Return(long emprestimoId);
        Task<GerericResponse<List<EmprestimoListDTO>>> GetActivesByAluno(long alunoId);
        Task<GerericResponse<List<object>>> GetTop();
        Task<GerericResponse<List<object>>> GetHistoryByPeriod(DateTime? inicio, DateTime? fim);
        Task<GerericResponse<List<object>>> GetDelayedLoans();

    }
}
