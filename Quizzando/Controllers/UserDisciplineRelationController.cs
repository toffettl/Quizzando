using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.UserDiscipline;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.UserDiscipline;
using Quizzando.Communication.Responses.UserDisciplineRelation;
using Quizzando.UseCases.UserDisciplineRelations.GetByDisciplineId;
using Quizzando.UseCases.UserDisciplineRelations.GetByUserId;
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

        [HttpGet("User/{userId}")]
        [ProducesResponseType(typeof(UserDisciplineRelationResponses), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByUserId(
            [FromServices] IGetUserDiciplineRelationsByUserIdUseCase useCase,
            [FromRoute] Guid userId)
        {
            var response = await useCase.Execute(userId);

            if (response.UserDisciplineRelations!.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("Discipline/{disciplineId}")]
        [ProducesResponseType(typeof(UserDisciplineRelationResponses), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByDisciplineId(
            [FromServices] IGetUserDisciplineRelationsByDisciplineIdUseCase useCase,
            [FromRoute] Guid disciplineId)
        {
            var response = await useCase.Execute(disciplineId);
            if (response.UserDisciplineRelations!.Count == 0)
            {
                return NoContent();
            }
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
