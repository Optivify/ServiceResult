namespace Optivify.ServiceResult
{
    public interface IResult
    {
        ResultStatus Status { get; set; }

        string? SuccessMessage { get; }

        IEnumerable<string>? ErrorMessages { get; }

        List<ValidationError>? ValidationErrors { get; }

        object? GetValue();
    }
}
