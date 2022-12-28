using System.Collections.Generic;

namespace Optivify.ServiceResult
{
    public interface IResult
    {
        ResultStatus Status { get; set; }

        IEnumerable<string> ErrorMessages { get; }

        List<ValidationError> ValidationErrors { get; }

        object GetValue();
    }
}
