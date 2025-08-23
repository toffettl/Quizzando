namespace Quizzando.Exception.ExceptionsBase
{
    public abstract class QuizzandoException : SystemException
    {
        protected QuizzandoException(string message) : base(message)
        {
        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
