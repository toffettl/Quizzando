﻿using System.Net;

namespace Quizzando.Exception.ExceptionsBase
{
    public class InvalidLoginException : QuizzandoException
    {
        public InvalidLoginException() : base(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
