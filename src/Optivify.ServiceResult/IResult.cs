namespace Optivify.ServiceResult;

public interface IResult
{
    bool IsSuccess { get; }

    public bool IsFailure { get; }

    ResultStatus Status { get; }

    string SuccessMessage { get; }

    IEnumerable<string> ErrorMessages { get; }

    List<ValidationError> ValidationErrors { get; }

    object? GetValue();
}
