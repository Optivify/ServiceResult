using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Optivify.ServiceResult.AspNetCore
{
    public static class ResultExtensions
    {
        public static string CombineErrorMessages(this IResult result, string sentenceSeparator = ".")
        {
            var sb = new StringBuilder();

            if (result.ErrorMessages == null)
            {
                return string.Empty;
            }

            foreach (var error in result.ErrorMessages)
            {
                if (!error.Any())
                {
                    continue;
                }

                sb.Append(error);

                if (Char.IsLetterOrDigit(error.Last()))
                {
                    sb.Append(sentenceSeparator);
                }

                sb.Append(' ');
            }

            return sb.ToString().Trim();
        }

        public static ActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
        {
            return controller.ToActionResult(result);
        }

        public static ActionResult ToActionResult(this Result result, ControllerBase controller)
        {
            return controller.ToActionResult(result);
        }

        public static ResultApiModel ToApiModel(this IResult result)
        {
            var resultApiModel = result.Status == ResultStatus.Invalid ?
                new ValidationResultApiModel() { ValidationErrors = result.ValidationErrors } :
                new ResultApiModel();

            resultApiModel.Success = result.Status == ResultStatus.Success;
            resultApiModel.Value = result.GetValue();

            return resultApiModel;
        }
    }
}