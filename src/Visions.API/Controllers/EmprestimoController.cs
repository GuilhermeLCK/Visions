using Microsoft.AspNetCore.Mvc;

namespace Visions.API.Controllers
{

    [Route("emprestimo")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
