
using System.Net;

namespace Quizzando.Exception.ExceptionsBase
{
    public class UnauthorizedException : QuizzandoException
    {
        public UnauthorizedException(string message) : base(message)
        {
            
        }
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            throw new NotImplementedException();
        }
    }
}
