using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.User;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.User;
using Quizzando.UseCases.Users.Delete;
using Quizzando.UseCases.Users.Get.All;
using Quizzando.UseCases.Users.Get.ById;
using Quizzando.UseCases.Users.Login;
using Quizzando.UseCases.Users.Register;
using Quizzando.UseCases.Users.Update;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserGetByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetUserByIdUseCase useCase,
            [FromRoute] Guid id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(List<UserGetByIdResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllUsersUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        [HttpDelete("{id}")]
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
    }
}
