namespace Optivify.ServiceResult;

public interface IResult
{
    ResultStatus Status { get; }

    bool IsSuccess { get; }

    bool IsFailure { get; }

    string? SuccessMessage { get; }

    string? ErrorMessage { get; }

    List<ValidationError>? ValidationErrors { get; }

    object? GetValue();
}

public interface IResult<out TValue> : IResult
{
    TValue? Value { get; }

    TValue? Data => Value;
}