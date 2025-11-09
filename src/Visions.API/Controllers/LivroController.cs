using Microsoft.AspNetCore.Mvc;
using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.UseCases.Livro;
namespace Visions.API.Controllers
{
    [Route("livros")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromServices]ILivroUseCase useCase , [FromBody]LivroRegisterDTO resquest)
        {   
            try
            {
                var resultado = await useCase.Register(resquest);
                if (resultado.Success)
                    return Created(string.Empty, resultado);
                else return BadRequest(resultado);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromServices] ILivroUseCase useCase, [FromQuery] LivroFiltersDTO filters)
        {
            try
            {
                var resultado = await useCase.GetAll(filters);
                if (resultado.Success)
                    return Ok(resultado);
                else return BadRequest(resultado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("disponiveis")] 
        public async Task<IActionResult> GetAvailable([FromServices] ILivroUseCase useCase)
        {
            try
            {
                var resultado = await useCase.GetAvailable();
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
