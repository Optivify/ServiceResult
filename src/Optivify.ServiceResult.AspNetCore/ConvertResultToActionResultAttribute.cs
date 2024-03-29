﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Optivify.ServiceResult;

public class ConvertResultToActionResultAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var objectResult = context.Result as ObjectResult;

        if (objectResult == null || objectResult.Value == null)
        {
            return;
        }

        if (objectResult.Value is not IResult result)
        {
            return;
        }

        if (context.Controller is not ControllerBase controller)
        {
            return;
        }

        context.Result = controller.ToActionResult(result);
    }
}
