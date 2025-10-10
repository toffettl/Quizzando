using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.Disciplines;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.Discipline;
using Quizzando.UseCases.Disciplines.Create;
using Quizzando.UseCases.Disciplines.Delete;
using Quizzando.UseCases.Disciplines.GetAll;
using Quizzando.UseCases.Disciplines.GetById;
using Quizzando.UseCases.Disciplines.Update;

namespace Quizzando.Controllers
{
    [Route("api/discipline")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(DisciplineResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateDisciplineUseCase useCase,
            [FromBody] DisciplineRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(DisciplineResponses), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllDisciplinesUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.Disciplines?.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DisciplineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetDisciplineByIdUseCase useCase,
            [FromRoute] Guid id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateDisciplineUseCase useCase,
            [FromRoute] Guid id,
            [FromBody] DisciplineRequest request)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteDisciplineUseCase useCase,
            [FromRoute] Guid id)
        {
            await useCase.Execute(id);

            return NoContent();
        }
    }
}
