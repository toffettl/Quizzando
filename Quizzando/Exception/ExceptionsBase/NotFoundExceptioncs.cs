using System.Net;

namespace Quizzando.Exception.ExceptionsBase
{
    public class NotFoundException : QuizzandoException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
