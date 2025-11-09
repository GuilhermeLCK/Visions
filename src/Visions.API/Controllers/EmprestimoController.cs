using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Visions.Application.DTOs.Emprestimo.Requests;
using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.UseCases.Aluno;
using Visions.Application.UseCases.Emprestimo;
using Visions.Application.UseCases.Livro;
using Visions.Domain.Interfaces;

namespace Visions.API.Controllers
{

    [Route("emprestimo")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromServices] IEmprestimoUseCase useCase, [FromBody] EmprestimoRegisterDTO resquest)
        {
            try
            {
                var resultado = await useCase.Register(resquest);
                if (resultado.Success)
                    return Created(string.Empty, resultado);
                else return BadRequest(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}/devolucao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Return([FromServices] IEmprestimoUseCase useCase, [FromRoute] long id)
        {
            try
            {
                var resultado = await useCase.Return(id);
                if (resultado.Success)
                    return Ok(resultado);
                else return BadRequest(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("ativos/{alunoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActivesByAluno([FromServices] IEmprestimoUseCase useCase, [FromRoute] long alunoId)
        {
            try
            {
                var resultado = await useCase.GetActivesByAluno(alunoId);
                if (resultado.Success)
                    return Ok(resultado);
                else return BadRequest(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet("relatorio/top-livros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTop([FromServices] IEmprestimoUseCase useCase)
        {
            try
            {   

                var resultado = await useCase.GetTop();
                if (resultado.Success)
                    return Ok(resultado);
                else return BadRequest(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("relatorio/historico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistoryByPeriod([FromServices] IEmprestimoUseCase useCase, [FromQuery] string? inicio , string? fim)
        {
            try
            {
                DateTime? inicioDate = null;
                DateTime? fimDate = null;
                if (!string.IsNullOrEmpty(inicio))
                    inicioDate = DateTime.ParseExact(inicio, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                if (!string.IsNullOrEmpty(fim))
                    fimDate = DateTime.ParseExact(fim, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                var resultado = await useCase.GetHistoryByPeriod(inicioDate, fimDate);
                if (resultado.Success)
                    return Ok(resultado);
                else return BadRequest(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("relatorio/atrasos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDelayedLoans([FromServices] IEmprestimoUseCase useCase)
        {
            try
            {
                var resultado = await useCase.GetDelayedLoans();
                if (resultado.Success)
                    return Ok(resultado);
                else return BadRequest(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
