namespace Quizzando.Security.Tokens.RecoverToken;

public interface IRecoverTokenService
{
    string GenerateCodeToken(string code);
    string? ValidateCodeToken(string token);
}
