using Microsoft.AspNetCore.Mvc;
using Visions.Application.DTOs.Aluno.Requests;
using Visions.Application.UseCases.Aluno;

namespace Visions.API.Controllers
{
    [Route("aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromServices] IAlunoUseCase useCase, [FromBody] AlunoRegisterDTO resquest)
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
    }
}
