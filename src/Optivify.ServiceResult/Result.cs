namespace Optivify.ServiceResult;

public class Result<TValue> : IResult<TValue>
{
    public ResultStatus Status { get; set; }

    public bool IsSuccess => Status == ResultStatus.Success;

    public bool IsFailure => !IsSuccess;

    public string? SuccessMessage { get; set; }

    public string? ErrorMessage => ErrorMessages.JoinStrings();

    public List<ValidationError>? ValidationErrors { get; set; }

    public IEnumerable<string>? ErrorMessages { get; set; }

    public TValue? Value { get; protected set; }

    public TValue? Data => Value;

    public static implicit operator TValue?(Result<TValue?> result) => result.Value;

    public static implicit operator Result<TValue?>(TValue? value) => new(value);

    public static implicit operator Result<TValue?>(Result result) => new(default(TValue?))
    {
        Status = result.Status,
        SuccessMessage = result.SuccessMessage,
        ErrorMessages = result.ErrorMessages,
        ValidationErrors = result.ValidationErrors
    };

    public Result(ResultStatus status)
    {
        Status = status;
    }

    public Result(TValue value)
    {
        Value = value;
    }

    public Result(ResultStatus status, TValue value)
    {
        Status = status;
        Value = value;
    }

    public object? GetValue() => Value;

    #region Success

    public static Result<TValue> Success(TValue? value, string? successMessage = null) => new(ResultStatus.Success) { Value = value, SuccessMessage = successMessage };

    #endregion

    #region Error

    public static Result<TValue> Error(params string[] errorMessages) => new(ResultStatus.Error) { ErrorMessages = errorMessages };

    #endregion

    #region Invalid

    public static Result<TValue> Invalid(params ValidationError[] validationErrors) =>
        new(ResultStatus.Invalid)
        {
            ValidationErrors = validationErrors.ToList()
        };

    public static Result<TValue> Invalid(IEnumerable<ValidationError> validationErrors) =>
        new(ResultStatus.Invalid)
        {
            ValidationErrors = validationErrors.ToList()
        };

    public static Result<TValue> Invalid(params string[] errorMessages) =>
        new(ResultStatus.Invalid)
        {
            ErrorMessages = errorMessages
        };

    #endregion

    #region Unauthorized

    public static Result<TValue> Unauthorized() => new(ResultStatus.Unauthorized);

    public static Result<TValue> Unauthorized(params string[] errorMessages) => new(ResultStatus.Unauthorized) { ErrorMessages = errorMessages };

    #endregion

    #region Forbidden

    public static Result<TValue> Forbidden() => new(ResultStatus.Forbidden);

    public static Result<TValue> Forbidden(params string[] errorMessages) => new(ResultStatus.Forbidden) { ErrorMessages = errorMessages };

    #endregion

    #region Not Found

    public static Result<TValue> NotFound() => new(ResultStatus.NotFound);

    public static Result<TValue> NotFound(params string[] errorMessages) => new(ResultStatus.NotFound) { ErrorMessages = errorMessages };

    #endregion
}

public class Result : Result<object>
{
    public Result(ResultStatus status) : base(status)
    {
    }

    #region Success

    public static Result Success() => new(ResultStatus.Success);

    public static Result<TValue?> Success<TValue>(TValue? value, string? successMessage = null) => new(ResultStatus.Success, value) { SuccessMessage = successMessage };

    #endregion

    #region Error

    public new static Result Error(params string[] errorMessages) => new(ResultStatus.Error) { ErrorMessages = errorMessages };

    #endregion

    #region Invalid

    public new static Result Invalid(params ValidationError[] validationErrors) =>
        new(ResultStatus.Invalid)
        {
            ValidationErrors = validationErrors.ToList()
        };

    public new static Result Invalid(IEnumerable<ValidationError> validationErrors) =>
        new(ResultStatus.Invalid)
        {
            ValidationErrors = validationErrors.ToList()
        };

    public new static Result Invalid(params string[] errorMessages) =>
        new(ResultStatus.Invalid)
        {
            ErrorMessages = errorMessages
        };

    #endregion

    #region Unauthorized

    public new static Result Unauthorized() => new(ResultStatus.Unauthorized);

    public new static Result Unauthorized(params string[] errorMessages) => new(ResultStatus.Unauthorized) { ErrorMessages = errorMessages };

    #endregion

    #region Forbidden

    public new static Result Forbidden() => new(ResultStatus.Forbidden);

    public new static Result Forbidden(params string[] errorMessages) => new(ResultStatus.Forbidden) { ErrorMessages = errorMessages };

    #endregion

    #region Not Found

    public new static Result NotFound() => new(ResultStatus.NotFound);

    public new static Result NotFound(params string[] errorMessages) => new(ResultStatus.NotFound) { ErrorMessages = errorMessages };

    #endregion
}