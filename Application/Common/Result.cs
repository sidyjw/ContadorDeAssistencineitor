namespace Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T? Value { get; set; }
        public string Message { get; set; } = string.Empty;

        public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };
        public static Result<T> Failure(string message) => new() { IsSuccess = false, Message = message };
    }
}
