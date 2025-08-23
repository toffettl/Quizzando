using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.User;
using Quizzando.UseCases.Users.Register;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
    }
}
