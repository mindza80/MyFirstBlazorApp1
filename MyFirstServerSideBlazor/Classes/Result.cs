namespace MyFirstServerSideBlazor.Classes
{
    public class Result<T>
    {
        public bool IsSuccessfull { get; init; }
        public string Error { get; init; }
        public T Content { get; init; }

        public static Result<T> Success(T content) => new Result<T>
        {
            IsSuccessfull = true,
            Error = string.Empty,
            Content = content
        };

        public static Result<T> Failure(T content, string error) => new Result<T>
        {
            IsSuccessfull = false,
            Error = error,
            Content = content
        };

        public static Result<T> Failure(string error) => new Result<T>
        {
            IsSuccessfull = false,
            Error = error,
            Content = default
        };
    }

    public class Result
    {
        public bool IsSuccessfull { get; init; }
        public string Error { get; init; }

        public static Result Success() => new Result
        {
            IsSuccessfull = true,
            Error = string.Empty
        };

        public static Result Failure(string error) => new Result
        {
            IsSuccessfull = false,
            Error = error
        };
    }
}
