namespace Domain.Handlers
{
    public class ResponsePackage<T>
    {
        public ResponsePackage()
        {
        }

        public ResponsePackage(string message, T result, object errors)
        {
            Message = message;
            Result = result;
            Errors = errors;
        }

        public string Message { get; set; }
        public T Result { get; set; }
        public object Errors { get; set; }
    }
}
