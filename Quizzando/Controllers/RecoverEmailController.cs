using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Quizzando.Communication.Requests.Email;
using Quizzando.Communication.Responses;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.Exception;
using Quizzando.Security.Tokens.RecoverToken;
using Quizzando.UseCases.RecoverEmail.EmailUseCase;
using Quizzando.UseCases.RecoverEmail.UpdatePasswordUseCase;

namespace Quizzando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecoverEmailController : ControllerBase
    {
        [HttpPost("send-code")]
        [ProducesResponseType(typeof(ResponseTokenJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseMessageJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendCode(
        [FromServices] ISendEmailUseCase emailService,
        [FromServices] IUserReadOnlyRepository userRepository,
        [FromServices] IRecoverTokenService tokenService,
        [FromBody] SendRecoverCodeRequest request)
        {
            var user = await userRepository.GetByEmail(request.Email);
            if (user == null)
                return BadRequest(new ResponseMessageJson { Message = ResourceErrorMessages.USER_NOT_FOUND });

            var code = CodeGenerator.GenerateCode();
            if (string.IsNullOrEmpty(code))
                return BadRequest(new ResponseMessageJson { Message = "Erro ao gerar código de recuperação" });

            await emailService.SendEmailAsync(request.Email, "Seu código", $"Seu código é: {code}");

            var token = tokenService.GenerateCodeToken(code);

            return Ok(new ResponseTokenJson { Token = token });
        }

        [HttpPost("reset-password")]
        [ProducesResponseType(typeof(ResponseMessageJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseMessageJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPassword(
            [FromServices] IRecoverTokenService tokenService,
            [FromServices] IUpdatePasswordUseCase useCase,
            [FromBody] ResetPassworRequest request)
        {
            var code = tokenService.ValidateCodeToken(request.Token);
            if (code == null || code != request.Code)
                return BadRequest(new ResponseMessageJson { Message = "Token inválido ou código incorreto" });

            await useCase.Execute(request.UserId, request.NewPassword);

            return Ok(new ResponseMessageJson { Message = "Senha atualizada com sucesso!" });
        }
    }
}

