using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.UserDiscipline;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.UserDiscipline;
using Quizzando.UseCases.UserDisciplines.Create;
using Quizzando.UseCases.UserDisciplines.GetByUserIdAndDisciplineId;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDisciplineRelationController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(UserDisciplineRelationResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateUserDisciplineUseCaseRelation useCase,
            [FromBody] UserDisciplineRelationRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete (
            [FromServices] IDeleteUserDisciplineRelationUseCase useCase,
            [FromRoute] Guid id)
        {
            await useCase.Execute(id);

            return NoContent();
        }
    }
}
