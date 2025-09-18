using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.UserDiscipline;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.UserDiscipline;
using Quizzando.UseCases.UserDisciplines.Create;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDisciplineController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(UserDisciplineResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateUserDisciplineUseCase useCase,
            [FromBody] UserDisciplineRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
