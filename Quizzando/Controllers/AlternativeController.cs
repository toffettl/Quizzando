using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.Alternatives;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.Alternatives;
using Quizzando.UseCases.Alternative.Create;
using Quizzando.UseCases.Alternative.Delete;
using Quizzando.UseCases.Alternative.Get.All;
using Quizzando.UseCases.Alternative.Get.ById;
using Quizzando.UseCases.Alternative.Update;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlternativeController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(AlternativeResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateAlternativeUseCase useCase,
            [FromBody] AlternativeRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(AlternativeResponses), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllAlternativesUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.Alternatives?.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AlternativeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetAlternativeByIdUseCase useCase,
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
            [FromServices] IUpdateAlternativeUseCase useCase,
            [FromRoute] Guid id,
            [FromBody] AlternativeRequest request)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteAlternativeUseCase useCase,
            [FromRoute] Guid id)
        {
            await useCase.Execute(id);

            return NoContent();
        }
    }
}