using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Optivify.ServiceResult.AspNetCore
{
    public class ConvertResultToActionResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var objectResult = context.Result as ObjectResult;

            if (objectResult == null || objectResult.Value == null)
            {
                return;
            }

            if (!(objectResult.Value is IResult result))
            {
                return;
            }

            if (!(context.Controller is ControllerBase controller))
            {
                return;
            }

            context.Result = controller.ToActionResult(result);
        }
    }
}
