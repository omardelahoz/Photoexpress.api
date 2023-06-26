namespace Photoexpress.Application.Exceptions
{
    public class PhotoexpressException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
        public PhotoexpressException(string message) : base(message)
        {

        }
        public PhotoexpressException(IDictionary<string, string[]> errors) : this("Se presentaron uno o mas errores de validacion")
        {
            Errors = errors;
        }
    }
}
