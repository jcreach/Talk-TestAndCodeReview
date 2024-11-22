using System;

namespace DummyProject.Common.Core;

public class Result<T>
{
    private Result(bool isSuccess, Error error, T value)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }
    
    public bool IsSuccess { get; }
    public T Value { get; }
    
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    
    public static Result<T> Success(T data) => new(true, Error.None, data);

    public static Result<T> Failure(Error error) => new(false, error, default!);
}