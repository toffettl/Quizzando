using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Responses.User;
using Quizzando.Communication.Responses;
using Quizzando.UseCases.Users.Refresh;
using Quizzando.Communication.Requests.User;

namespace Quizzando.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRefreshJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Refresh(
            [FromServices] IRefreshTokenUseCase useCase,
            [FromBody] RequestRefreshJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
