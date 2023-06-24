namespace Optivify.ServiceResult;

public record ValidationError
{
    public string? PropertyName { get; set; }

    public string? ErrorMessage { get; set; }

    public string? ErrorCode { get; set; }

    public ValidationSeverity? Severity { get; set; }
}
