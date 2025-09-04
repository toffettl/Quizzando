using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.Email;
using Quizzando.UseCases.Users.RecoverPassword;
using Quizzando.UseCases.Users.ResetPassword;
using Quizzando.UseCases.Users.SendRecoveryEmail;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(
      [FromServices] SendRecoveryEmailUseCase useCase,
      [FromBody] EmailRequest request)
        {
            var token = await useCase.ExecuteAsync(request.To!);
            return Ok(new { message = "Email enviado com sucesso!", token });
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword(
            [FromServices] ResetPasswordUseCase useCase,
            [FromBody] ResetPasswordRequest request)
        {
            var success = await useCase.ExecuteAsync(request.Token, request.Code, request.NewPassword);
            if (!success) return BadRequest(new { message = "Token ou código inválido!" });

            return Ok(new { message = "Senha atualizada com sucesso!" });
        }
    }
}

