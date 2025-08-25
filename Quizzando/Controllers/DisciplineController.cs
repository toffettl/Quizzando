using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.Disciplines;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.Disciplines;
using Quizzando.UseCases.Disciplines.Create;
using Quizzando.UseCases.Disciplines.GetById;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
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
        [ProducesResponseType(typeof(DisciplineResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] GetDisciplineByIdUseCase useCase,
            [FromRoute] Guid id)
        {
            var response = await  useCase.Execute(id);

            return Ok(response);
        }
    }
}
