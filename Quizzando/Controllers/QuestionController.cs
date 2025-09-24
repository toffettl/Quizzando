using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.Question;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.Disciplines;
using Quizzando.Communication.Responses.Question;
using Quizzando.UseCases.Questions.Create;
using Quizzando.UseCases.Questions.Delete;
using Quizzando.UseCases.Questions.GetAll;
using Quizzando.UseCases.Questions.GetById;
using Quizzando.UseCases.Questions.GetQuestionsByDisciplineId;
using Quizzando.UseCases.Questions.UpdateById;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(QuestionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateQuestionUseCase useCase,
            [FromBody] QuestionRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(QuestionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllQuestionsUseCase useCase
            )
        {
            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuestionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetByIdQuestionUseCase useCase,
            [FromRoute] Guid id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateById(
            [FromServices] IUpdateByIdQuestionUseCase useCase,
            [FromRoute] Guid id,
            [FromBody] QuestionRequest request)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById(
            [FromServices] IDeleteQuestionUseCase useCase,
            [FromRoute] Guid id)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpGet("discipline/{disciplineId}")]
        [ProducesResponseType(typeof(QuestionsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByCourseId(
            [FromServices] IGetQuestionsByDisplineIdUseCase useCase,
            [FromRoute] Guid disciplineId)
        {
            var response = await useCase.Execute(disciplineId);

            if (response.Questions?.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
    
}
