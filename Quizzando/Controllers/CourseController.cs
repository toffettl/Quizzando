using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.Course;
using Quizzando.Communication.Requests.Question;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.Course;
using Quizzando.Communication.Responses.Question;
using Quizzando.UseCases.Courses.Create;
using Quizzando.UseCases.Courses.Delete;
using Quizzando.UseCases.Courses.GetAll;
using Quizzando.UseCases.Courses.GetById;
using Quizzando.UseCases.Courses.Update;
using Quizzando.UseCases.Questions.GetQuiz;

namespace Quizzando.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpPost()]
        [ProducesResponseType(typeof(CourseResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateCourse(
            [FromServices] ICreateCourseUseCase useCase,
            [FromBody] CreateCourseRequest request)
        {
            var response = await useCase.Execute(request);
            
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetCourseById([FromServices] IGetCourseByIdUseCase useCase,
            [FromRoute] Guid id
        )
        {
            var response = await useCase.Execute(id);
            
            return Ok(response);
        }
        
        
        [HttpGet()]
        [ProducesResponseType(typeof(GetAllCoursesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllCoursesUseCase useCase)
        {
            var response = await useCase.Execute();
            
            return Ok(response);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CourseResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourse(
            [FromServices] IUpdateCourseUseCase useCase,
            [FromRoute] Guid id,
            [FromBody] UpdateCourseRequest request
        )
        {
            var response = await useCase.Execute(id, request);
            
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourse(
            [FromServices] IDeleteCourseUseCase useCase,
            [FromRoute] Guid id)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpGet("quiz/{disciplineId}")]
        [ProducesResponseType(typeof(ResponseQuizJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRandomQuestionsByDiscipline(
            [FromServices] IGetQuizUseCase useCase,
            [FromRoute] Guid disciplineId)
        {
            var request = new RequestQuizJson
            {
                DisciplineId = disciplineId
            };

            var response = await useCase.ExecuteAsync(request);

            return Ok(response);
        }

    }
}