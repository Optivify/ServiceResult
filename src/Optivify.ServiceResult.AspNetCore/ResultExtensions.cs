using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Optivify.ServiceResult.AspNetCore
{
    public static class ResultExtensions
    {
        public static string CombineErrorMessages(this IResult result)
        {
            var sb = new StringBuilder();

            foreach (var error in result.ErrorMessages)
            {
                sb.AppendLine(error);

                if (!error.EndsWith("."))
                {
                    sb.Append('.');
                }
            }

            return sb.ToString();
        }

        public static ActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
        {
            return controller.ToActionResult(result);
        }

        public static ActionResult ToActionResult(this Result result, ControllerBase controller)
        {
            return controller.ToActionResult(result);
        }
    }
}