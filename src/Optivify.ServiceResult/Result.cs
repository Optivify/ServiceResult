namespace Optivify.ServiceResult
{
    public class Result<TValue> : IResult
    {
        public bool IsSuccess => Status == ResultStatus.Success;

        public bool IsSuccessWithValue => Status == ResultStatus.Success && Value != null;

        public bool IsFailure => !IsSuccess;

        public ResultStatus Status { get; set; }

        public string SuccessMessage { get; set; } = string.Empty;

        public IEnumerable<string> ErrorMessages { get; set; } = Enumerable.Empty<string>();

        public List<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();

        public TValue? Value { get; protected set; }

        public static implicit operator TValue?(Result<TValue> result) => result.Value;

        public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value);

        public static implicit operator Result<TValue>(Result result) => new Result<TValue>(default(TValue))
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

        public Result(TValue? value)
        {
            Value = value;
        }

        public Result(ResultStatus status, TValue value)
        {
            Status = status;
            Value = value;
        }

        public object? GetValue()
        {
            return Value;
        }

        #region Success

        public static Result<TValue> Success(TValue value)
        {
            return new Result<TValue>(ResultStatus.Success, value);
        }

        public static Result<TValue> Success<TValue>(TValue value)
        {
            return new Result<TValue>(ResultStatus.Success, value);
        }

        public static Result<TValue> Success(TValue value, string successMessage)
        {
            return new Result<TValue>(ResultStatus.Success, value) { SuccessMessage = successMessage };
        }

        public static Result<TValue> SuccessWithMessage(string successMessage)
        {
            return new Result<TValue>(ResultStatus.Success) { SuccessMessage = successMessage };
        }

        #endregion

        #region Error

        public static Result<TValue> Error(params string[] errorMessages)
        {
            return new Result<TValue>(ResultStatus.Error) { ErrorMessages = errorMessages };
        }

        #endregion

        #region Invalid

        public static Result<TValue> Invalid(params string[] errorMessages)
        {
            return new Result(ResultStatus.Invalid)
            {
                ErrorMessages = errorMessages
            };
        }

        public static Result<TValue> Invalid(params ValidationError[] validationErrors)
        {
            return new Result(ResultStatus.Invalid)
            {
                ValidationErrors = validationErrors.ToList()
            };
        }

        public static Result<TValue> Invalid(List<ValidationError> validationErrors)
        {
            return new Result<TValue>(ResultStatus.Invalid)
            {
                ValidationErrors = validationErrors
            };
        }

        #endregion

        #region Unauthorized

        public static Result<TValue> Unauthorized()
        {
            return new Result<TValue>(ResultStatus.Unauthorized);
        }

        public static Result<TValue> Unauthorized(params string[] errorMessages)
        {
            return new Result<TValue>(ResultStatus.Unauthorized) { ErrorMessages = errorMessages };
        }

        #endregion

        #region Forbidden

        public static Result<TValue> Forbidden()
        {
            return new Result<TValue>(ResultStatus.Forbidden);
        }

        public static Result<TValue> Forbidden(params string[] errorMessages)
        {
            return new Result<TValue>(ResultStatus.Forbidden) { ErrorMessages = errorMessages };
        }

        #endregion

        #region Not Found

        public static Result<TValue> NotFound()
        {
            return new Result<TValue>(ResultStatus.NotFound);
        }

        public static Result<TValue> NotFound(params string[] errorMessages)
        {
            return new Result<TValue>(ResultStatus.NotFound) { ErrorMessages = errorMessages };
        }

        #endregion
    }

    public class Result : Result<object>
    {
        public Result(ResultStatus status) : base(status)
        {
        }

        #region Success

        public static Result Success()
        {
            return new Result(ResultStatus.Success);
        }

        public static new Result SuccessWithMessage(string successMessage)
        {
            return new Result(ResultStatus.Success) { SuccessMessage = successMessage };
        }

        #endregion

        #region Error

        public static new Result Error(params string[] errorMessages)
        {
            return new Result(ResultStatus.Error) { ErrorMessages = errorMessages };
        }

        #endregion

        #region Invalid

        public static new Result Invalid(params string[] errorMessages)
        {
            return new Result(ResultStatus.Invalid)
            {
                ErrorMessages = errorMessages
            };
        }

        public static new Result Invalid(params ValidationError[] validationErrors)
        {
            return new Result(ResultStatus.Invalid)
            {
                ValidationErrors = validationErrors.ToList()
            };
        }

        public static new Result Invalid(List<ValidationError> validationErrors)
        {
            return new Result(ResultStatus.Invalid)
            {
                ValidationErrors = validationErrors
            };
        }

        #endregion

        #region Unauthorized

        public static new Result Unauthorized()
        {
            return new Result(ResultStatus.Unauthorized);
        }

        public static new Result Unauthorized(params string[] errorMessages)
        {
            return new Result(ResultStatus.Unauthorized) { ErrorMessages = errorMessages };
        }

        #endregion

        #region Forbidden

        public static new Result Forbidden()
        {
            return new Result(ResultStatus.Forbidden);
        }

        public static new Result Forbidden(params string[] errorMessages)
        {
            return new Result(ResultStatus.Forbidden) { ErrorMessages = errorMessages };
        }

        #endregion

        #region Not Found

        public static new Result NotFound()
        {
            return new Result(ResultStatus.NotFound);
        }

        public static new Result NotFound(params string[] errorMessages)
        {
            return new Result(ResultStatus.NotFound) { ErrorMessages = errorMessages };
        }

        #endregion
    }
}