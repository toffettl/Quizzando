namespace Quizzando.Security.Tokens.RecoverToken;

public class CodeGenerator
{
    public static string GenerateCode(int length = 5)
    {
        var random = new Random();
        string code = "";
        for (int i = 0; i < length; i++)
            code += random.Next(0, 10);
        return code;
    }
}
