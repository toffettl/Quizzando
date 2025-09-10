using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses.User;
using Quizzando.Communication.Responses;
using Quizzando.UseCases.Users.Register;
using Quizzando.UseCases.Users.Login;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserRegisterResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
          [FromServices] IRegisterUserUseCase useCase,
          [FromBody] UserRegisterRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(Quizzando.Communication.Responses.ResponseTokenJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
           [FromServices] IDoLoginUseCase useCase,
           [FromBody] RequestLoginJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
