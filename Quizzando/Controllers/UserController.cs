using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.User;
using Quizzando.UseCases.Users.Delete;
using Quizzando.UseCases.Users.Get.All;
using Quizzando.UseCases.Users.Get.ById;
using Quizzando.UseCases.Users.GetByRanking;
using Quizzando.UseCases.Users.Login;
using Quizzando.UseCases.Users.Register;
using Quizzando.UseCases.Users.Update;

namespace Quizzando.Controllers
{
    [Route("api/user")]
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

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(UserGetByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetUserByIdUseCase useCase,
            [FromRoute] Guid id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet("ranking")]
        [ProducesResponseType(typeof(List<UserGetByRankingResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByRanking(
            [FromServices] IGetUsersByRankingUseCase useCase,
            [FromQuery] int page,
            [FromQuery] int pageSize)
        {
            var response = await useCase.Execute(page, pageSize);
            
            return Ok(response);
        }

        [HttpGet("all")]
        [Authorize]
        [ProducesResponseType(typeof(List<UserGetByIdResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllUsersUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteUserUseCase useCase,
            [FromRoute] Guid id)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateUserUseCase useCase,
            [FromRoute] Guid id,
            [FromBody] UserUpdateRequest userUpdateRequest)
        {
            await useCase.Execute(id, userUpdateRequest);
            return NoContent();
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


        [HttpPatch("{id}/score/{newScore}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateScore(
            [FromServices] IUpdateUserScoreUseCase useCase,
            [FromRoute] Guid id,
            [FromRoute] int newScore)
        {
            await useCase.Execute(id, newScore);
            return NoContent();
        }
    }
}
