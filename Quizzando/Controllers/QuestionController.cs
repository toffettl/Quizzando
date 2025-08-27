using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.Question;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.Question;
using Quizzando.UseCases.Questions.Create;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(QuestionResponse),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateQuestionUseCase useCase,
            [FromBody] QuestionRequest request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
        //[HttpGet]
        //[ProducesResponseType(typeof(QuestionResponse), StatusCodes.Status200Ok)]
        //[ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status204NoContent)]
        //public async Taks<IActionResult> GetAll(
        //    [FromServices] IGetAllQuestionsUseCase useCase
        //    )
        //{
        //    var response = await useCase.Execute();

        //    return Ok(response);
        //}
    }
    
}
