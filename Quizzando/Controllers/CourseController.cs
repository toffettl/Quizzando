using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.Course;
using Quizzando.Communication.Responses;
using Quizzando.Communication.Responses.Course;
using Quizzando.Models;
using Quizzando.UseCases.Courses.Create;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CourseController : ControllerBase
    {
        [HttpPost()]
        [ProducesResponseType(typeof(CreateCourseResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateCourse(
            [FromServices] ICreateCourseUseCase useCase,
            [FromBody] CreateCourseRequest request)
        {
            var response = await useCase.Execute(request);
            
            return Ok(response);
        }
    }
}