using System.Collections.Generic;
using System.Linq;

namespace Elsekily.Application.Common.Models;

/// <summary>
/// Generic result wrapper. Use Result.Success(value) or Result.Failure("error message").
/// </summary>
public class Result<T> : Result
{
    public T? Value { get; init; }

    private Result(bool succeeded, T? value, List<string> errors)
        : base(succeeded, errors)
    {
        Value = value;
    }

    public static Result<T> Success(T value)
        => new Result<T>(true, value, new());

    public static new Result<T> Failure(string error)
        => new Result<T>(false, default, new List<string> { error });

    public static new Result<T> Failure(params string[] errors)
        => new Result<T>(false, default, errors.ToList());

    public static new Result<T> Failure(IEnumerable<string> errors)
        => new Result<T>(false, default, errors.ToList());
}

public class Result
{
    public bool IsSuccess { get; init; }
    public List<string> Errors { get; init; } = new();

    protected Result(bool succeeded, List<string> errors)
    {
        IsSuccess = succeeded;
        Errors = errors;
    }

    public static Result Success()
        => new Result(true, new List<string>());

    public static Result Failure(string error)
        => new Result(false, new List<string> { error });

    public static Result Failure(params string[] errors)
        => new Result(false, errors.ToList());

    public static Result Failure(IEnumerable<string> errors)
        => new Result(false, errors.ToList());
}
