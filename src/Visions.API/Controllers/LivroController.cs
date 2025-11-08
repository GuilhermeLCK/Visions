using Microsoft.AspNetCore.Mvc;
using Visions.Application.DTOs;
using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.UseCases.Livro.Listing;
using Visions.Application.UseCases.Livro.Register;
using Visions.Domain.Interfaces;
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
                var resultado = await useCase.Execute(resquest);
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
        public async Task<IActionResult> GetAll([FromServices] ILivroListingUseCase useCase, [FromQuery] LivroFiltersDTO filters)
        {
            try
            {
                var resultado = await useCase.ExecuteAll(filters);
                if (resultado.Success)
                    return Created(string.Empty, resultado);
                else return BadRequest(resultado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("disponiveis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAvailable([FromServices] ILivroListingUseCase useCase)
        {
            try
            {
                var resultado = await useCase.ExecuteAvailable();
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
