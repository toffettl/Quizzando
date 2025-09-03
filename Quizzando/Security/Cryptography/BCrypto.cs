using BC = BCrypt.Net.BCrypt;

namespace Quizzando.Security.Cryptography
{
    public class BCrypto : IPasswordEncripter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }

        public bool Verify(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
